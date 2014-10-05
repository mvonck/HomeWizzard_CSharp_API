
using System;

namespace HomeWizzardConnector.Models.Enums
{
    public enum SensorType
    {
        Switch,

        Doorbell,

        Smoke,

        Motion,
    }

    internal static class SensorTypeExtensions
    {
        internal static SensorType ToPublicEnum(this HWConnector.JsonResult.Models.Enums.SensorType jsonObject)
        {
            switch (jsonObject)
            {
                case HWConnector.JsonResult.Models.Enums.SensorType.Doorbell:
                    return SensorType.Doorbell;
                case HWConnector.JsonResult.Models.Enums.SensorType.Motion:
                    return SensorType.Motion;
                case HWConnector.JsonResult.Models.Enums.SensorType.Smoke:
                    return SensorType.Smoke;
                case HWConnector.JsonResult.Models.Enums.SensorType.Switch:
                    return SensorType.Switch;
                default:
                    throw new NotSupportedException(String.Format("The json enum value {0} is not supported.", jsonObject));
            }
        }
    }
}
