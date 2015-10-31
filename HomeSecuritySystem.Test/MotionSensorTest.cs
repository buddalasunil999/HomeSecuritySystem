using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeSecuritySystem.Report;

namespace HomeSecuritySystem.Test
{
    [TestClass]
    public class MotionSensorTest
    {
        MotionSensor sensor = new MotionSensor(2);

        [TestMethod]
        public void TestMotionSensorIsOn()
        {
            Assert.IsFalse(sensor.IsOn);
        }

        [TestMethod]
        public void TestMotionSensorDetected()
        {
            Assert.IsFalse(sensor.Detected);
        }

        [TestMethod]
        public void TestMotionSensorId()
        {
            Assert.IsNotNull(sensor.Id);
            Assert.AreEqual(2, sensor.Id);
        }

        [TestMethod]
        public void TestMotionSensorType()
        {
            Assert.AreEqual(SensorType.Motion, sensor.Type);
        }

        [TestMethod]
        public void TestMotionSensorSwitchOn()
        {
            sensor.SwitchOn();
            Assert.IsTrue(sensor.IsOn);
        }

        [TestMethod]
        public void TestMotionSensorSwitchOff()
        {
            sensor.SwitchOff();
            Assert.IsFalse(sensor.IsOn);
        }

        [TestMethod]
        public void TestMotionSensorTrigger()
        {
            sensor.Trigger();
            Assert.IsTrue(sensor.Detected);
        }

        [TestMethod]
        public void TestMotionSensorResetTrigger()
        {
            sensor.ResetTrigger();
            Assert.IsFalse(sensor.Detected);
        }
    }
}
