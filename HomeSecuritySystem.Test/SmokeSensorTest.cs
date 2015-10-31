using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeSecuritySystem.Report;
using HomeSecurityControl;

namespace HomeSecuritySystem.Test
{
    [TestClass]
    public class SmokeSensorTest
    {
        SmokeSensor sensor = new SmokeSensor(1);

        [TestMethod]
        public void TestSmokeSesorDetected()
        {
            Assert.IsFalse(sensor.Detected);
        }

        [TestMethod]
        public void TestSmokeSensorType()
        {
            Assert.AreEqual(SensorType.Smoke, sensor.Type);
        }

        [TestMethod]
        public void TestSmokeSensorId()
        {
            Assert.IsNotNull(sensor.Id);
            Assert.AreEqual(1, sensor.Id);
        }

        [TestMethod]
        public void TestSmokeSensorIsOn()
        {
            Assert.IsFalse(sensor.IsOn);
        }

        [TestMethod]
        public void TestSmokeSensorSwitchOn()
        {
            sensor.SwitchOn();
            Assert.IsTrue(sensor.IsOn);
        }

        [TestMethod]
        public void TestSmokeSensorSwitchOff()
        {
            sensor.SwitchOff();
            Assert.IsFalse(sensor.IsOn);
        }

        [TestMethod]
        public void TestSmokeSensorTriggerDetection()
        {
            sensor.Trigger();
            Assert.IsTrue(sensor.Detected);
        }

        [TestMethod]
        public void TestSmokeSensorResetTrigger()
        {
            sensor.ResetTrigger();
            Assert.IsFalse(sensor.Detected);
        }
    }
}
