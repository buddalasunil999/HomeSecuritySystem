using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeSecuritySystem.Test
{
    [TestClass]
    public class SecurityAlarmTest
    {
        [TestMethod]
        public void TestIsOn()
        {
            SecurityAlarm alarm = new SecurityAlarm();
            Assert.IsTrue(alarm.IsOn);
        }

        [TestMethod]
        public void TestIsActive()
        {
            SecurityAlarm alarm = new SecurityAlarm();
            Assert.IsTrue(alarm.IsActive);
        }

        [TestMethod]
        public void TestSoundAlarm()
        {
            SecurityAlarm alarm = new SecurityAlarm();
            alarm.SoundAlarm();
        }

        [TestMethod]
        public void TestStopAlarm()
        {
            SecurityAlarm alarm = new SecurityAlarm();
            alarm.StopAlarm();
        }
    }
}
