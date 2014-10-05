using Newtonsoft.Json;

namespace HomeWizzardConnector.HWConnector.JsonResult
{
    internal class BaseResponse<TResponse> where TResponse : class
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("request")]
        public Request Request { get; set; }

        [JsonProperty("response")]
        public TResponse Response { get; set; }
    }
}
