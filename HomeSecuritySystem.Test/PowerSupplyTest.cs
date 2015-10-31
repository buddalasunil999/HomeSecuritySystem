using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeSecuritySystem.Test
{
    [TestClass]
    public class PowerSupplyTest
    {
        PowerSupply power = new PowerSupply();

        [TestMethod]
        public void TestPowerSupply_IsOn()
        {
            Assert.IsFalse(power.IsOn);
        }

        [TestMethod]
        public void TestPowerSupply_IsLowBattery()
        {
            Assert.IsFalse(power.IsLowBattery);
        }

        [TestMethod]
        public void TestPowerSupply_TriggerLowPower()
        {
            power.TriggerLowPower();
            Assert.IsTrue(power.IsLowBattery);
        }

        [TestMethod]
        public void TestPowerSupply_ResetLowPower()
        {
            power.ResetLowPower();
            Assert.IsFalse(power.IsLowBattery);
        }

        [TestMethod]
        public void TestPowerSupply_SwitchOn()
        {
            power.SwitchOn();
            Assert.IsTrue(power.IsOn);
        }

        [TestMethod]
        public void TestPowerSupply_SwitchOff()
        {
            power.SwitchOff();
            Assert.IsFalse(power.IsOn);
        }
    }
}
