using HomeWizzardConnector.HWConnector.JsonResult.Extensions;
using HomeWizzardConnector.HWConnector.JsonResult.Models.Enums;
using Newtonsoft.Json;

namespace HomeWizzardConnector.HWConnector.JsonResult.Models
{
    internal class KakuSensor : Sensor
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(SensorTypeConverter))]
        public SensorType Type { get; set; }

        [JsonProperty("timestamp")]
        public string TimeStamp { get; set; }

        [JsonProperty("cameraid")]
        public int? CameraId { get; set; }
    }
}
