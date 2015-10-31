using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeSecuritySystem.Test
{
    [TestClass]
    public class SecurityAlarmTest
    {
        [TestMethod]
        public void TestAlarmIsOn()
        {
            SecurityAlarm alarm = new SecurityAlarm();
            Assert.IsFalse(alarm.IsOn);
        }

        [TestMethod]
        public void TestAlarmIsActive()
        {
            SecurityAlarm alarm = new SecurityAlarm();
            Assert.IsFalse(alarm.IsActive);
        }

        [TestMethod]
        public void TestSoundAlarm()
        {
            SecurityAlarm alarm = new SecurityAlarm();
            alarm.SoundAlarm();
            Assert.IsTrue(alarm.IsActive);
        }

        [TestMethod]
        public void TestStopAlarm()
        {
            SecurityAlarm alarm = new SecurityAlarm();
            alarm.StopAlarm();
            Assert.IsFalse(alarm.IsActive);
        }
    }
}
