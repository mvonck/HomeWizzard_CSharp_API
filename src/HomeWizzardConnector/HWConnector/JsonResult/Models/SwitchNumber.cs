using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWizzardConnector.HWConnector.Extensions;
using HomeWizzardConnector.HWConnector.JsonResult.Models.Enums;
using Newtonsoft.Json;

namespace HomeWizzardConnector.HWConnector.JsonResult.Models
{
    class SwitchNumber
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        public SwitchEnum Status { get; set; }

        [JsonProperty("favorite")]
        [JsonConverter(typeof(YesNoConverter))]
        public bool IsFavorite { get; set; }
    }
}
