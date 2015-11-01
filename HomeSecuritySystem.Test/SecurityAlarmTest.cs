using HomeSecurityControl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeSecuritySystem.Test
{
    [TestClass]
    public class SecurityAlarmTest
    {
        SecurityAlarm alarm = new SecurityAlarm();

        [TestMethod]
        public void TestAlarmIsOn()
        {
            Assert.IsFalse(alarm.IsOn);
        }

        [TestMethod]
        public void TestAlarmIsActive()
        {
            Assert.IsFalse(alarm.IsActive);
        }

        [TestMethod]
        public void TestSoundAlarm()
        {
            alarm.SoundAlarm();
            Assert.IsTrue(alarm.IsActive);
        }

        [TestMethod]
        public void TestStopAlarm()
        {
            alarm.StopAlarm();
            Assert.IsFalse(alarm.IsActive);
        }

        [TestMethod]
        public void TestAlarmSwitchOn()
        {
            alarm.SwitchOn();
            Assert.IsTrue(alarm.IsOn);
        }

        [TestMethod]
        public void TestAlarmSwitchOff()
        {
            alarm.SwitchOff();
            Assert.IsFalse(alarm.IsOn);
        }
    }
}
