using HomeWizzardConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using HomeWizzardConnector.Models;

namespace HomeWizzard.EventListener.SensorEvent
{
    class SensorEventListener : ISensorEventListener
    {
        private readonly ISensorEventHandler _sensorChangedHandler;
        private readonly IHomeWizzardService _homeWizzardService;

        public SensorEventListener(IHomeWizzardService homeWizzardService, ISensorEventHandler sensorChangedHandler)
        {
            _sensorChangedHandler = sensorChangedHandler;
            _homeWizzardService = homeWizzardService;
        }

        public void Listen(CancellationToken clt, int interval)
        {
            var currentSensors = _homeWizzardService.GetSensorsAsync().Result.Switches;

            while (!clt.IsCancellationRequested)
            {
                Thread.Sleep(interval);
                var newSensorsCollection = _homeWizzardService.GetSensorsAsync().Result;
                var collection = newSensorsCollection.Switches
                .Select(s => new
                {
                    newSensor = s,
                    oldSensor = currentSensors.FirstOrDefault(x => x.Id == s.Id)
                })
                .Where(s => s.oldSensor != null)
                .Where(s => IsChanged(s.oldSensor, s.newSensor))
                .ToList();

                foreach (var col in collection)
                {
                    var old = col.oldSensor;
                    var news = col.newSensor;
                    _sensorChangedHandler.HandleEvent(old, news);
                }
            }
        }

        public void OnChangedEvent<TSensor>(Action<TSensor, TSensor> action) where TSensor : HomeWizzardConnector.Models.Sensor
        {
            _sensorChangedHandler.RegisterOnEvent(action);
        }


        private bool IsChanged(Sensor oldSensor, Sensor newSensor)
        {
            if (oldSensor == null)
                throw new ArgumentNullException("oldSensor");

            if (newSensor == null)
                throw new ArgumentNullException("newSensor");

            if (oldSensor.GetType() != newSensor.GetType())
                throw new Exception(String.Format("Can't compare two sensors from the same type. Oldsensor type: '{0}', newSensor type: '{1}'", oldSensor.GetType(), newSensor.GetType()));

            if (oldSensor.Id != newSensor.Id)
                throw new Exception(String.Format("Sensors to compare must have the same id. Old sensor id: '{0}', newSensor id: '{1}'", oldSensor.Id, newSensor.Id));

            if (oldSensor is Switch)
            {
                if (compareKakuSensor(oldSensor as Switch, newSensor as Switch))
                    return true;
            }

            return false;
        }

        private bool compareKakuSensor(Switch oldSensor, Switch newSensor)
        {
            if (oldSensor.Status == newSensor.Status)
                return false;

            oldSensor.Status = newSensor.Status;
            return true;
        }
    }
}
