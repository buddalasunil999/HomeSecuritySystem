using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeSecuritySystem.Report;

namespace HomeSecuritySystem.Test
{
    [TestClass]
    public class SmokeSensorTest
    {
        [TestMethod]
        public void TestSesorDetected()
        {
            SmokeSensor sensor = new SmokeSensor();
            Assert.IsTrue(sensor.Detected);
        }

        [TestMethod]
        public void TestSensorType()
        {
            SmokeSensor sensor = new SmokeSensor();
            Assert.AreEqual(SensorType.Smoke, sensor.Type);
        }

        [TestMethod]
        public void TestSensorId()
        {
            SmokeSensor sensor = new SmokeSensor();
            Assert.IsNotNull(sensor.Id);
            Assert.AreEqual(1, sensor.Id);
        }

        [TestMethod]
        public void TestSensorIsOn()
        {
            SmokeSensor sensor = new SmokeSensor();
            Assert.IsTrue(sensor.IsOn);
        }
    }
}
