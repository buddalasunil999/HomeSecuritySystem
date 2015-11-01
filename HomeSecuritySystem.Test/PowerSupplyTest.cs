using HomeSecurityControl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeSecuritySystem.Test
{
    [TestClass]
    public class PowerSupplyTest
    {
        PowerSupply _power = new PowerSupply();

        [TestMethod]
        public void TestPowerSupply_IsOn()
        {
            Assert.IsFalse(_power.IsOn);
        }

        [TestMethod]
        public void TestPowerSupply_IsLowBattery()
        {
            Assert.IsFalse(_power.IsLowBattery);
        }

        [TestMethod]
        public void TestPowerSupply_TriggerLowPower()
        {
            _power.TriggerLowPower();
            Assert.IsTrue(_power.IsLowBattery);
        }

        [TestMethod]
        public void TestPowerSupply_ResetLowPower()
        {
            _power.ResetLowPower();
            Assert.IsFalse(_power.IsLowBattery);
        }

        [TestMethod]
        public void TestPowerSupply_SwitchOn()
        {
            _power.SwitchOn();
            Assert.IsTrue(_power.IsOn);
        }

        [TestMethod]
        public void TestPowerSupply_SwitchOff()
        {
            _power.SwitchOff();
            Assert.IsFalse(_power.IsOn);
        }
    }
}
