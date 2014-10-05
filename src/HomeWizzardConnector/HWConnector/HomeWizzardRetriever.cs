using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWizzardConnector.ApiConnector;
using HomeWizzardConnector.ApiConnector.Exceptions;
using Newtonsoft.Json;

namespace HomeWizzardConnector.HWConnector
{
    internal class HomeWizzardRetriever : Retriever
    {
        public HomeWizzardRetriever(string serverAddress, string password) : base(() => new HomeWizzardConnector(serverAddress, password))
        {
        }

        /// <summary>
        /// Gets all main Cora Categories from Umbrella with children counted
        /// </summary>
        /// <returns>A json Object with Cora Categories</returns>
        /// <exception cref="RetrieverException">When categories could not be retrieved</exception>
        public JsonResult.GetSwitchNumbers GetSwitchNumbers()
        {
            const string action = "/swlist";

            //Try to get jsonResult
            string response;
            try
            {
                response = RetrieveResultWithRetry(action);
            }
            catch (ConnectorException e)
            {
                throw new NotImplementedException("catch is not implemented yet", e);
                //throw new RetrieverException("Faq Items for Search could not be retrieved (url: " + GetFaqlistUrl + "?id=" + query + "&pageSize=" + max.ToString() + "&targetGroupId=" + Accolade.EnvironmentIds.UmbrellaTargetGroupID + ")", e);
            }
            //parse json to Object
            var result = JsonConvert.DeserializeObject<JsonResult.GetSwitchNumbers>(response);

            //if result is null return new list, else return result
            return result;
        }
    }
}
