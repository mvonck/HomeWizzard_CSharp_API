using HomeWizzardConnector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWizzard.EventListener.SensorEvent
{
    interface ISensorEventHandler
    {
        void RegisterOnEvent<TSensor>(Action<TSensor, TSensor> doAction) where TSensor : Sensor;

        void HandleEvent(Sensor oldSensor, Sensor newSensor);
    }
}
