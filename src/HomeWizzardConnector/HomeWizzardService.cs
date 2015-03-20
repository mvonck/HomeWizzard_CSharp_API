using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWizzardConnector.HWConnector;
using HomeWizzardConnector.Models;
using HomeWizzardConnector.Models.Enums;

namespace HomeWizzardConnector
{
    public class HomeWizzardService : IHomeWizzardService
    {
        private readonly HomeWizzardRetriever _homeWizzardRetriever;

        public HomeWizzardService(string serverAddress, string password)
        {
            _homeWizzardRetriever = new HomeWizzardRetriever(serverAddress, password);
        }

        public async Task<IEnumerable<Switch>> GetSwitchNumbersAsync()
        {
            var result = await _homeWizzardRetriever.GetSwitchNumbersAsync().ConfigureAwait(false); ;

            return result
                .Response
                .Select(x => new Switch(x));
        }

        public async Task<IEnumerable<Sensor>> GetSensorsAsync()
        {
            var jsonObject = await _homeWizzardRetriever.GetSensorsAsync().ConfigureAwait(false);

            return new List<Sensor>()
               .Union(jsonObject.Response.Switches.Select(x => new Switch(x)))
               .Union(jsonObject.Response.KakuSensors.Select(x => new KakuSensor(x)))
               .Union(jsonObject.Response.Scenes.Select(x => new Scene(x)));
        }

        public async Task<IEnumerable<Scene>> GetScenesAsync()
        {
            var result = await _homeWizzardRetriever.GetScenesAsync().ConfigureAwait(false); ;

            return result
                .Response
                .Select(x => new Scene(x));
        }

        public async Task SetSwitchAsync(int switchId, SwitchStatus status)
        {
            await _homeWizzardRetriever.SetSwitchAsync(switchId, status.ToJsonStatus()).ConfigureAwait(false); ;
        }

        public async Task SetSceneAsync(int sceneId, SwitchStatus status)
        {
            await _homeWizzardRetriever.SetSceneAsync(sceneId, status.ToJsonStatus()).ConfigureAwait(false); ;
        }

        public async Task OperateDimmerAsync(int dimmerId, short dimmerNumber)
        {
            if (dimmerNumber < 0 || dimmerNumber > 255)
                throw new ArgumentOutOfRangeException("dimmerNumber", "Only a value between 0 and 255 is allowd for the dimmer");

            await _homeWizzardRetriever.OperateDimmerAsync(dimmerId, dimmerNumber).ConfigureAwait(false);
        }
    }
}
