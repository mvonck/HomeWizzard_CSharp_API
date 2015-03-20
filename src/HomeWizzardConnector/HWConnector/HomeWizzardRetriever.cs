using System;
using System.Collections.Generic;
using HomeWizzardConnector.ApiConnector;
using HomeWizzardConnector.HWConnector.JsonResult;
using HomeWizzardConnector.HWConnector.JsonResult.Models;
using HomeWizzardConnector.HWConnector.JsonResult.Models.Enums;
using System.Threading.Tasks;

namespace HomeWizzardConnector.HWConnector
{
    internal class HomeWizzardRetriever : Retriever
    {
        public HomeWizzardRetriever(string serverAddress, string password) : base(() => new HomeWizzardConnector(serverAddress, password))
        {
        }

        public async Task<BaseResponse<IEnumerable<Switch>>> GetSwitchNumbersAsync()
        {
            return await GetAndParseActionAsync<BaseResponse<IEnumerable<Switch>>>(action: "/swlist").ConfigureAwait(false); ;
        }

        public async Task<BaseResponse<GetSensorsResponse>> GetSensorsAsync()
        {
            return await GetAndParseActionAsync<BaseResponse<GetSensorsResponse>>(action: "/get-sensors").ConfigureAwait(false); ;
        }

        public async Task<BaseResponse<IEnumerable<Scene>>> GetScenesAsync()
        {
            return await GetAndParseActionAsync<BaseResponse<IEnumerable<Scene>>>(action: "/gplist").ConfigureAwait(false); ;
        }

        public async Task<BaseResponse> SetSwitchAsync(int switchId, SwitchStatus status)
        {
            return await GetAndParseActionAsync<BaseResponse>(action: String.Format("/sw/{0}/{1}", switchId, status.ToString().ToLower())).ConfigureAwait(false); 
        }

        public async Task<BaseResponse> SetSceneAsync(int sceneId, SwitchStatus status)
        {
            return await GetAndParseActionAsync<BaseResponse>(action: String.Format("/gp/{0}/{1}", sceneId, status.ToString().ToLower())).ConfigureAwait(false);
        }

        public async Task<BaseResponse> OperateDimmerAsync(int switchId, short dimmerNumber)
        {
            if(dimmerNumber < 0 || dimmerNumber > 255)
                throw new ArgumentOutOfRangeException("dimmerNumber", "Only a value between 0 and 255 is allowd for the dimmer");

            return await GetAndParseActionAsync<BaseResponse>(action: String.Format("sw/dim/{0}/{1}", switchId, dimmerNumber)).ConfigureAwait(false);
        }
    }
}

