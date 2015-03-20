using System.Collections.Generic;
using System.Linq;
using HomeWizzardConnector.HWConnector.JsonResult;
using System;

namespace HomeWizzardConnector.Models
{
    public class SensorsCollection
    {
        public SensorsCollection()
        {
        }

        internal SensorsCollection(GetSensorsResponse jsonResponse)
        {
            if (jsonResponse == null)
                throw new ArgumentNullException("jsonResponse");

            Switches = jsonResponse.Switches.Select(x => new Switch(x));
            Scenes = jsonResponse.Scenes.Select(x => new Scene(x));
            KakuSensors = jsonResponse.KakuSensors.Select(x => new KakuSensor(x));
        }

        public IEnumerable<Switch> Switches { get; set; }

        public IEnumerable<Scene> Scenes { get; set; }

        public IEnumerable<KakuSensor> KakuSensors { get; set; } 
    }
}
