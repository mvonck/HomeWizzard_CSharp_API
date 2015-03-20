using HomeWizzard.EventListener.SensorEvent;
using HomeWizzardConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWizzard.EventListener
{
    public class HomeWizzardListener : IHomeWizzardListener
    {
        private readonly IHomeWizzardService _homeWizzardService;
        private readonly ISensorEventListener _sensorEventListener;

        public HomeWizzardListener(IHomeWizzardService homeWizzardService)
        {
            _homeWizzardService = homeWizzardService;
            _sensorEventListener = new SensorEventListener(_homeWizzardService, new SensorEventHandler());
        }

        public ISensorEventListener SensorEventListener
        {
            get { return _sensorEventListener; }
        }
    }
}
