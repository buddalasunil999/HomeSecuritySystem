using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeSecuritySystem.Test
{
    [TestClass]
    public class ControllerTest
    {
        [TestMethod]
        public void TestIsSystemReady()
        {
            SecurityController controller = new SecurityController();
            bool isReady = controller.IsSystemReady();
            Assert.IsTrue(isReady);
        }
    }
}
