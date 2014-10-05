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

        public BaseResponse<IEnumerable<Switch>> GetSwitchNumbers()
        {
            return GetAndParseAction<BaseResponse<IEnumerable<Switch>>>(action: "/swlist");
        }

        public BaseResponse<GetSensorsResponse> GetSensors()
        {
            return GetAndParseAction<BaseResponse<GetSensorsResponse>>(action: "/get-sensors");
        }

        public BaseResponse<IEnumerable<Scene>> GetScenes()
        {
            return GetAndParseAction<BaseResponse<IEnumerable<Scene>>>(action: "/gplist");
        }
    }
}

