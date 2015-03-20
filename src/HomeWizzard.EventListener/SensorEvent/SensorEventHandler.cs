using HomeWizzardConnector.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWizzard.EventListener.SensorEvent
{
    class SensorEventHandler : ISensorEventHandler
    {
        private readonly ConcurrentDictionary<Type, Action<Sensor, Sensor>> _eventTable = new ConcurrentDictionary<Type, Action<Sensor, Sensor>>();

        public void HandleEvent(Sensor oldSensor, Sensor newSensor)
        {
            if (oldSensor == null)
                throw new ArgumentNullException("oldSensor");

            if (newSensor == null)
                throw new ArgumentNullException("newSensor");

            foreach (var e in _eventTable.Where(e => e.Key.IsInstanceOfType(oldSensor)))
            {
                try
                {
                    e.Value(oldSensor, newSensor);
                }
                catch (Exception ex)
                {
                    throw new Exception(
                        String.Format("Failed to handle sensorEvent with type '{0}'. See inner exception for more details.", oldSensor.GetType()), ex);
                }
            }
        }

        public void RegisterOnEvent<TSensor>(Action<TSensor, TSensor> doAction)
            where TSensor : Sensor
        {
            if (doAction == null)
                throw new ArgumentNullException("doAction");

            var key = (typeof(TSensor));

            //Cast Action param T2 from type TEventData to parent EventData, by using another anonymous function.
            var castedMethod = new Action<Sensor, Sensor>((oldSensor, newSensor) =>
            {
                if (oldSensor == null)
                    throw new ArgumentNullException("oldSensor");

                if (newSensor == null)
                    throw new ArgumentNullException("newSensor");

                var castedOldSensor = oldSensor as TSensor;
                if (castedOldSensor == null)
                {
                    throw new InvalidOperationException(
                        String.Format("Unexpected oldSensor type encountered: '{0}' but expected was '{1}'",
                            oldSensor.GetType().FullName, typeof(TSensor).FullName
                        )
                    );
                }
                var castedNewSensor = newSensor as TSensor;
                if (castedNewSensor == null)
                {
                    throw new InvalidOperationException(
                        String.Format("Unexpected newSensor type encountered: '{0}' but expected was '{1}'",
                            castedNewSensor.GetType().FullName, typeof(TSensor).FullName
                        )
                    );
                }

                doAction(castedOldSensor, castedNewSensor);
            });

            //Support multiple events on 1 type.
            if (!_eventTable.TryAdd(key, castedMethod))
            {
                _eventTable[key] += castedMethod;
            }
        }
    }
}
