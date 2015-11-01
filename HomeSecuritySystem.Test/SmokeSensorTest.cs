using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeSecuritySystem.Report;
using HomeSecurityControl;

namespace HomeSecuritySystem.Test
{
    [TestClass]
    public class SmokeSensorTest
    {
        SmokeSensor _sensor = new SmokeSensor(1);

        [TestMethod]
        public void TestSmokeSesorDetected()
        {
            Assert.IsFalse(_sensor.Detected);
        }

        [TestMethod]
        public void TestSmokeSensorType()
        {
            Assert.AreEqual(SensorType.Smoke, _sensor.Type);
        }

        [TestMethod]
        public void TestSmokeSensorId()
        {
            Assert.IsNotNull(_sensor.Id);
            Assert.AreEqual(1, _sensor.Id);
        }

        [TestMethod]
        public void TestSmokeSensorIsOn()
        {
            Assert.IsFalse(_sensor.IsOn);
        }

        [TestMethod]
        public void TestSmokeSensorSwitchOn()
        {
            _sensor.SwitchOn();
            Assert.IsTrue(_sensor.IsOn);
        }

        [TestMethod]
        public void TestSmokeSensorSwitchOff()
        {
            _sensor.SwitchOff();
            Assert.IsFalse(_sensor.IsOn);
        }

        [TestMethod]
        public void TestSmokeSensorTriggerDetection()
        {
            _sensor.Trigger();
            Assert.IsTrue(_sensor.Detected);
        }

        [TestMethod]
        public void TestSmokeSensorResetTrigger()
        {
            _sensor.ResetTrigger();
            Assert.IsFalse(_sensor.Detected);
        }
    }
}
