using System;
using HomeWizzardConnector.HWConnector.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace HomeWizzardConnector.Test.HWConnector.Extensions
{
    [TestClass]
    public class YesNoConverterTest
    {
        [TestMethod]
        public void SerializeObject_ShouldWorkWith_YesAndNo()
        {
            Assert.AreEqual(JsonConvert.SerializeObject(true, new YesNoConverter()), "\"yes\"");
            Assert.AreEqual(JsonConvert.SerializeObject(false, new YesNoConverter()), "\"no\"");

            Assert.IsTrue(JsonConvert.DeserializeObject<bool>("\"yes\"", new YesNoConverter()));
            Assert.IsFalse(JsonConvert.DeserializeObject<bool>("\"no\"", new YesNoConverter()));

        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void SerializeObject_WithNotSupportedInput_ShouldThrowException()
        {
            JsonConvert.DeserializeObject<bool>("\"blaat\"", new YesNoConverter());
        }

    }
}
