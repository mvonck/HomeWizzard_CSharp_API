using Newtonsoft.Json;

namespace HomeWizzardConnector.HWConnector.JsonResult
{
    internal class Response
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("request")]
        public Request Request { get; set; }
    }
}
