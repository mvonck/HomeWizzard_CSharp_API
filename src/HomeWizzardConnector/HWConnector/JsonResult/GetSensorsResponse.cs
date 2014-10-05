using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWizzardConnector.HWConnector.JsonResult.Models;
using Newtonsoft.Json;

namespace HomeWizzardConnector.HWConnector.JsonResult
{
    internal class GetSensorsResponse
    {
        [JsonProperty("switches")]
        public IEnumerable<Switch> Switches { get; set; }

        [JsonProperty("scenes")]
        public IEnumerable<Scene> Scenes { get; set; }

        [JsonProperty("kakusensors")]
        public IEnumerable<KakuSensor> KakuSensors { get; set; } 
    }
}
