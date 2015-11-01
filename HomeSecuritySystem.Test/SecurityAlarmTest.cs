using HomeSecurityControl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeSecuritySystem.Test
{
    [TestClass]
    public class SecurityAlarmTest
    {
        SecurityAlarm _alarm = new SecurityAlarm();

        [TestMethod]
        public void TestAlarmIsOn()
        {
            Assert.IsFalse(_alarm.IsOn);
        }

        [TestMethod]
        public void TestAlarmIsActive()
        {
            Assert.IsFalse(_alarm.IsActive);
        }

        [TestMethod]
        public void TestSoundAlarm()
        {
            _alarm.SoundAlarm();
            Assert.IsTrue(_alarm.IsActive);
        }

        [TestMethod]
        public void TestStopAlarm()
        {
            _alarm.StopAlarm();
            Assert.IsFalse(_alarm.IsActive);
        }

        [TestMethod]
        public void TestAlarmSwitchOn()
        {
            _alarm.SwitchOn();
            Assert.IsTrue(_alarm.IsOn);
        }

        [TestMethod]
        public void TestAlarmSwitchOff()
        {
            _alarm.SwitchOff();
            Assert.IsFalse(_alarm.IsOn);
        }
    }
}
