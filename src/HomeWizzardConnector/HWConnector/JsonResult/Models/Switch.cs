using HomeWizzardConnector.HWConnector.JsonResult.Models.Enums;
using Newtonsoft.Json;

namespace HomeWizzardConnector.HWConnector.JsonResult.Models
{
    class Switch : Sensor
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        public SwitchStatus Status { get; set; }
    }
}
