using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWizzardConnector.ApiConnector;
using HomeWizzardConnector.ApiConnector.Exceptions;
using HomeWizzardConnector.HWConnector.JsonResult;
using HomeWizzardConnector.HWConnector.JsonResult.Models;
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
        public BaseResponse<IEnumerable<Switch>> GetSwitchNumbers()
        {
            return GetAndParseAction<BaseResponse<IEnumerable<Switch>>>(action: "/swlist");
        }

        /// <summary>
        /// Gets all main Cora Categories from Umbrella with children counted
        /// </summary>
        /// <returns>A json Object with Cora Categories</returns>
        /// <exception cref="RetrieverException">When categories could not be retrieved</exception>
        public BaseResponse<GetSensorsResponse> GetSensors()
        {
            return GetAndParseAction<BaseResponse<GetSensorsResponse>>(action: "/get-sensors");
        }
    }
}

