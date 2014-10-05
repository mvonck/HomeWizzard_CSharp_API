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
            return GetAndParseAction<JsonResult.GetSwitchNumbers>(action: "/swlist");
        }
    }
}
