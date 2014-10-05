using HomeWizzardConnector.HWConnector.Extensions;
using Newtonsoft.Json;

namespace HomeWizzardConnector.HWConnector.JsonResult.Models
{
    internal class Sensor
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("favorite")]
        [JsonConverter(typeof(YesNoConverter))]
        public bool IsFavorite { get; set; }
    }
}
