using System;
using HomeWizzardConnector.HWConnector.JsonResult.Models.Enums;
using Newtonsoft.Json;

namespace HomeWizzardConnector.HWConnector.JsonResult.Extensions
{
    internal class SensorTypeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString().ToLower());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            foreach (SensorType sensorType in (SensorType[]) Enum.GetValues(typeof (SensorType)))
            {
                if (sensorType.ToString().ToLower() == reader.Value.ToString())
                    return sensorType;
            }

            throw new NotSupportedException(String.Format("The value '{0}' is not supported to convert to SensorType.", reader.Value));  
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(SensorType);
        }
    }
}
