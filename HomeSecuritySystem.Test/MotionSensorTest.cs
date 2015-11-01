using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeSecuritySystem.Report;
using HomeSecurityControl;

namespace HomeSecuritySystem.Test
{
    [TestClass]
    public class MotionSensorTest
    {
        MotionSensor _sensor = new MotionSensor(2);

        [TestMethod]
        public void TestMotionSensorIsOn()
        {
            Assert.IsFalse(_sensor.IsOn);
        }

        [TestMethod]
        public void TestMotionSensorDetected()
        {
            Assert.IsFalse(_sensor.Detected);
        }

        [TestMethod]
        public void TestMotionSensorId()
        {
            Assert.IsNotNull(_sensor.Id);
            Assert.AreEqual(2, _sensor.Id);
        }

        [TestMethod]
        public void TestMotionSensorType()
        {
            Assert.AreEqual(SensorType.Motion, _sensor.Type);
        }

        [TestMethod]
        public void TestMotionSensorSwitchOn()
        {
            _sensor.SwitchOn();
            Assert.IsTrue(_sensor.IsOn);
        }

        [TestMethod]
        public void TestMotionSensorSwitchOff()
        {
            _sensor.SwitchOff();
            Assert.IsFalse(_sensor.IsOn);
        }

        [TestMethod]
        public void TestMotionSensorTrigger()
        {
            _sensor.Trigger();
            Assert.IsTrue(_sensor.Detected);
        }

        [TestMethod]
        public void TestMotionSensorResetTrigger()
        {
            _sensor.ResetTrigger();
            Assert.IsFalse(_sensor.Detected);
        }
    }
}
