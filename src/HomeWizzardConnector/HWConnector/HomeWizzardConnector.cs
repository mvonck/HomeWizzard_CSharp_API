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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverAddress">The server address of the HomeWizzard</param>
        /// <param name="password">The password of the HomeWizzard</param>
        public HomeWizzardConnector(string serverAddress, string password)
        {
            if(string.IsNullOrEmpty(serverAddress))
                throw new ArgumentNullException("serverAddress");

            if(string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");

            if(serverAddress.Contains("http"))
                throw new ArgumentException("don't set http in your server address", "serverAddress");

            BaseUrl = String.Format("http://{0}/{1}", serverAddress, password);

            WebClient = new WebClient();
        }

        public void Dispose()
        {
            WebClient.Dispose();
        }

        public string BaseUrl { get; set; }
        public WebClient WebClient { get; set; }
    }
}
