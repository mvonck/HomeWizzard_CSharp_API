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

        public IEnumerable<SwitchNumber> GetSwitchNumbers()
        {
            return _homeWizzardRetriever
                .GetSwitchNumbers()
                .SwitchNumbers
                .Select(x => new SwitchNumber(x));
        }

        public IEnumerable<object> GetSensors()
        {
            throw new NotImplementedException();
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
