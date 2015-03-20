using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HomeWizzardConnector.ApiConnector;

namespace HomeWizzardConnector.HWConnector
{
    internal class HomeWizzardConnector : IConnector
    {
        private readonly Uri _baseUri;
        private readonly WebClient _webClient;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverAddress">The server address of the HomeWizzard</param>
        /// <param name="password">The password of the HomeWizzard</param>
        public HomeWizzardConnector(string serverAddress, string password)
        {
            if (string.IsNullOrEmpty(serverAddress))
                throw new ArgumentNullException("serverAddress");

            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");

            if (serverAddress.Contains("http"))
                throw new ArgumentException("don't set http in your server address", "serverAddress");

            _baseUri = new Uri(String.Format("http://{0}/{1}", serverAddress, password));
            _webClient = new WebClient();
        }

        public void Dispose()
        {
            WebClient.Dispose();
        }

        public Uri BaseUri
        {
            get
            {
                return _baseUri;
            }
        }

        public WebClient WebClient
        {
            get
            {
                return _webClient;
            }
        }
    }
}
