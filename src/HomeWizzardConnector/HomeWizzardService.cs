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

        public void SwitchScene(int sceneId, SwitchStatus switchStatus)
        {
            throw new NotImplementedException();
        }

        public void OperateDimmer(short value)
        {
            throw new NotImplementedException();
        }
    }
}
