using System;
using System.Collections.Generic;
using HomeWizzardConnector.ApiConnector;
using HomeWizzardConnector.HWConnector.JsonResult;
using HomeWizzardConnector.HWConnector.JsonResult.Models;
using HomeWizzardConnector.HWConnector.JsonResult.Models.Enums;

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

        public BaseResponse SetSwitch(int switchId, SwitchStatus status)
        {
            return GetAndParseAction<BaseResponse>(action: String.Format("/sw/{0}/{1}", switchId, status.ToString().ToLower()));
        }

        public BaseResponse SetScene(int sceneId, SwitchStatus status)
        {
            return GetAndParseAction<BaseResponse>(action: String.Format("/gp/{0}/{1}", sceneId, status.ToString().ToLower()));
        }

        public BaseResponse OperateDimmer(int switchId, short dimmerNumber)
        {
            if(dimmerNumber < 0 || dimmerNumber > 255)
                throw new ArgumentOutOfRangeException("dimmerNumber", "Only a value between 0 and 255 is allowd for the dimmer");

            return GetAndParseAction<BaseResponse>(action: String.Format("sw/dim/{0}/{1}", switchId, dimmerNumber));
        }
    }
}

