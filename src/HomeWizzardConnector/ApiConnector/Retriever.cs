using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HomeWizzardConnector.ApiConnector.Exceptions;
using Newtonsoft.Json;

namespace HomeWizzardConnector.ApiConnector
{
    /// <summary>
    /// Class for retrieving a string result from REST API
    /// </summary>
    internal class Retriever : IRetriever
    {
        protected Func<IConnector> GetConnector { get; set; }
        protected const int RetryTimeout = 1000;

        /// <summary>
        /// Default contstructor to set required GetConnector
        /// </summary>
        /// <param name="getGetConnector">A function that's provide a new connector that will be used for requests to API</param>
        public Retriever(Func<IConnector> getGetConnector)
        {
            if (getGetConnector == null)
                throw new ArgumentNullException("getGetConnector");

            GetConnector = getGetConnector;
        }

        protected TJsonResult GetAndParseAction<TJsonResult>(string action)
        {
            //Try to get jsonResult
            string response;
            try
            {
                response = RetrieveResultWithRetry(action);
            }
            catch (ConnectorException e)
            {
                throw new RetrieverException(String.Format("Failed to do the following action '{0}', see inner exception for details.", action), e);
            }

            //Try to parse result to json
            return JsonConvert.DeserializeObject<TJsonResult>(response);
        }

        /// <summary>
        /// Gets a result as string from a REST API url
        /// Tries x times 
        /// </summary>
        /// <param name="apiActionUrl">The api url after base url (/action)</param>
        /// <param name="numRetries">The number to retry, if null the default will be used</param>
        /// <returns>The result of the given url as string</returns>
        /// <exception cref="ConnectorException">if getting data is failed after numRetries</exception>
        private string RetrieveResultWithRetry(string apiActionUrl, int numRetries = 3)
        {
            using (var connector = GetConnector())
            {
                //set rest api address
                var address = new Uri(connector.BaseUrl + apiActionUrl);

                //try xx times
                for (var retryNr = 0; retryNr < numRetries; retryNr++)
                {
                    try
                    {
                        connector.WebClient.Encoding = Encoding.UTF8;
                        return connector.WebClient.DownloadString(address);
                    }
                    catch (Exception e)
                    {
                        //if we can't retry anymore throw exception, else wait xx miliseconds
                        if (retryNr >= (numRetries - 1))
                        {
                            throw new ConnectorException("Retrieving failed after " + numRetries + " times", e);
                        }

                        //else wait xx miliseconds
                        Thread.Sleep(RetryTimeout);
                    }
                }

                //somehow the application gets here. 
                throw new ConnectorException("Something did go wrong, application can't come here");
            }
        }
    }
}
