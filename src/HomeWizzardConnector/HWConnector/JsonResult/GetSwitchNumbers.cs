using System.Collections;
using System.Collections.Generic;
using HomeWizzardConnector.HWConnector.JsonResult.Models;
using Newtonsoft.Json;

namespace HomeWizzardConnector.HWConnector.JsonResult
{
    internal class GetSwitchNumbers : Response
    {
        [JsonProperty("response")]
        public IEnumerable<SwitchNumber> SwitchNumbers { get; set; }
    }
}
