using HomeWizzardConnector.Models.Enums;
using Newtonsoft.Json;

namespace HomeWizzardConnector.Models
{
    public class KakuSensor : Sensor
    {
        public KakuSensor() :base()
        { }

        internal KakuSensor(HWConnector.JsonResult.Models.KakuSensor jsonObject)
            : base(jsonObject)
        {
            Status = jsonObject.Status;
            Type = jsonObject.Type.ToPublicEnum();
            TimeStamp = jsonObject.TimeStamp;
            CameraId = jsonObject.CameraId;
        }
        
        public string Status { get; set; }

        public SensorType Type { get; set; }

        public string TimeStamp { get; set; }

        public int? CameraId { get; set; }
    }
}
