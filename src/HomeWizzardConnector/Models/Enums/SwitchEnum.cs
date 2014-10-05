using System;

namespace HomeWizzardConnector.Models.Enums
{
    public enum SwitchEnum
    {
        On,

        Off,
    }

    internal static class SwitchEnumExtensions
    {
        internal static SwitchEnum ToPublicEnum(this HWConnector.JsonResult.Models.Enums.SwitchEnum jsonObject)
        {
            switch (jsonObject)
            {
                case HWConnector.JsonResult.Models.Enums.SwitchEnum.On:
                    return SwitchEnum.On;
                case HWConnector.JsonResult.Models.Enums.SwitchEnum.Off:
                    return SwitchEnum.Off;
                default:
                    throw new NotSupportedException(String.Format("The json enum value {0} is not supported.", jsonObject));
            }
        }
    }
}
