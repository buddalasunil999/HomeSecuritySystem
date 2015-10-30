using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeSecuritySystem.Report;

namespace HomeSecuritySystem.Test
{
    [TestClass]
    public class MotionSensorTest
    {
        [TestMethod]
        public void TestMotionSensorIsOn()
        {
            MotionSensor sensor = new MotionSensor();
            Assert.IsTrue(sensor.IsOn);
        }

        [TestMethod]
        public void TestMotionSensorDetected()
        {
            MotionSensor sensor = new MotionSensor();
            Assert.IsTrue(sensor.Detected);
        }

        [TestMethod]
        public void TestMotionSensorId()
        {
            MotionSensor sensor = new MotionSensor();
            Assert.IsNotNull(sensor.Id);
            Assert.AreEqual(2, sensor.Id);
        }

        [TestMethod]
        public void TestMotionSensorType()
        {
            MotionSensor sensor = new MotionSensor();
            Assert.AreEqual(SensorType.Motion, sensor.Type);
        }
    }
}
