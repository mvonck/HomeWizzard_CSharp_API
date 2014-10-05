using Newtonsoft.Json;

namespace HomeWizzardConnector.HWConnector.JsonResult
{
    internal class BaseResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("request")]
        public Request Request { get; set; }
    }

    internal class BaseResponse<TResponse> : BaseResponse
        where TResponse : class
    {
        [JsonProperty("response")]
        public TResponse Response { get; set; }
    }
}
