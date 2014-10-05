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

        public IEnumerable<Switch> GetSwitchNumbers()
        {
            return _homeWizzardRetriever
                .GetSwitchNumbers()
                .Response
                .Select(x => new Switch(x));
        }

        public SensorsCollection GetSensors()
        {
            var jsonObject = _homeWizzardRetriever.GetSensors();
            return new SensorsCollection(jsonObject.Response);
        }

        public IEnumerable<Scene> GetScenes()
        {
            return _homeWizzardRetriever
                .GetScenes()
                .Response
                .Select(x => new Scene(x));
        }

        public void SetSwitch(int switchId, SwitchStatus status)
        {
            _homeWizzardRetriever.SetSwitch(switchId, status.ToJsonStatus());
        }

        public void SetScene(int sceneId, SwitchStatus status)
        {
            _homeWizzardRetriever.SetScene(sceneId, status.ToJsonStatus());
        }

        public void OperateDimmer(int dimmerId, short dimmerNumber)
        {
            if (dimmerNumber < 0 || dimmerNumber > 255)
                throw new ArgumentOutOfRangeException("dimmerNumber", "Only a value between 0 and 255 is allowd for the dimmer");

            _homeWizzardRetriever.OperateDimmer(dimmerId, dimmerNumber);
        }
    }
}
