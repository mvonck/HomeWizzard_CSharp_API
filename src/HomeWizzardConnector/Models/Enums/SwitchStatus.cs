using System;

namespace HomeWizzardConnector.Models.Enums
{
    public enum SwitchStatus
    {
        On,

        Off,
    }

    internal static class SwitchEnumExtensions
    {
        internal static SwitchStatus ToPublicEnum(this HWConnector.JsonResult.Models.Enums.SwitchStatus jsonObject)
        {
            switch (jsonObject)
            {
                case HWConnector.JsonResult.Models.Enums.SwitchStatus.On:
                    return SwitchStatus.On;
                case HWConnector.JsonResult.Models.Enums.SwitchStatus.Off:
                    return SwitchStatus.Off;
                default:
                    throw new NotSupportedException(String.Format("The json enum value {0} is not supported.", jsonObject));
            }
        }

        internal static HWConnector.JsonResult.Models.Enums.SwitchStatus ToJsonStatus(this SwitchStatus status)
        {
            switch (status)
            {
                case SwitchStatus.On:
                    return HWConnector.JsonResult.Models.Enums.SwitchStatus.On;
                case SwitchStatus.Off:
                    return HWConnector.JsonResult.Models.Enums.SwitchStatus.Off;
                default:
                    throw new NotSupportedException(String.Format("The enum value {0} is not supported for json.", status));
            }
        }
    }
}
