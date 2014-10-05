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

        public IEnumerable<object> GetScenes()
        {
            throw new NotImplementedException();
        }

        public void SwitchDevice(int switchId, SwitchEnum switchEnum)
        {
            throw new NotImplementedException();
        }

        public void SwitchScene(int sceneId, SwitchEnum switchEnum)
        {
            throw new NotImplementedException();
        }

        public void OperateDimmer(short value)
        {
            throw new NotImplementedException();
        }
    }
}
