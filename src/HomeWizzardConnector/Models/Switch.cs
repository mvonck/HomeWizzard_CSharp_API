using HomeWizzardConnector.Models.Enums;

namespace HomeWizzardConnector.Models
{
    public class Switch : Sensor
    {
        public Switch()
            : base()
        {
        }

        internal Switch(HWConnector.JsonResult.Models.Switch jsonObject)
            :base(jsonObject)
        {
            Type = jsonObject.Type;
            Status = jsonObject.Status.ToPublicEnum();
        }

        public string Type { get; set; }

        public SwitchEnum Status { get; set; }
    }
}
