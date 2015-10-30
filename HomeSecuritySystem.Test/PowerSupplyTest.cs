using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSecuritySystem.Test
{
    [TestClass]
    public class PowerSupplyTest
    {
        [TestMethod]
        public void TestPowerSupplyIsOn()
        {
            PowerSupply power = new PowerSupply();
            Assert.IsTrue(power.IsOn);
        }

        [TestMethod]
        public void TestPowerSupplyIsLowBattery()
        {
            PowerSupply power = new PowerSupply();
            Assert.IsTrue(power.IsLowBattery);
        }
    }
}
