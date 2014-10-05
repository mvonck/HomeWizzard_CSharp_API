using System;
using Newtonsoft.Json;

namespace HomeWizzardConnector.HWConnector.JsonResult.Extensions
{
    internal class YesNoConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((bool)value) ? "yes" : "no");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.Value.ToString())
            {
                case "yes" :
                    return true;
                case "no" :
                    return false;
                default :
                    throw new NotSupportedException(String.Format("The value '{0}' is not supported to convert to bool, only 'yes' or 'no' are supported.", reader.Value));
            }
                
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(bool);
        }
    }
}
