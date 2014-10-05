using System;
using HomeWizzardConnector.HWConnector.JsonResult.Extensions;
using HomeWizzardConnector.HWConnector.JsonResult.Models;
using HomeWizzardConnector.HWConnector.JsonResult.Models.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace HomeWizzardConnector.Test.HWConnector.JsonResult.Extensions
{
    [TestClass]
    public class SensorTypeConverterTest
    {
        [TestMethod]
        public void SerializeObject_ShouldWorkWith_ValidInput()
        {
            //Test if each value is converted correctly if lowercase
            foreach (SensorType sensorType in (SensorType[])Enum.GetValues(typeof(SensorType)))
            {
                var sensorAsJsonFormat = String.Format("\"{0}\"", sensorType.ToString().ToLower());

                //Test serialize
                Assert.AreEqual(JsonConvert.SerializeObject(sensorType, new SensorTypeConverter()), sensorAsJsonFormat);

                //Test desirialize
                Assert.AreEqual(sensorType, JsonConvert.DeserializeObject<SensorType>(sensorAsJsonFormat, new SensorTypeConverter()));

            } 
        }
    }
}
