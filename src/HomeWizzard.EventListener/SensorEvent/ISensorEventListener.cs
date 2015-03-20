using HomeWizzardConnector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWizzard.EventListener.SensorEvent
{
    public interface ISensorEventListener
    {
        void OnChangedEvent<TSensor>(Action<TSensor, TSensor> action) where TSensor : Sensor;

        void Listen(CancellationToken clt, int interval);
    }
}
