using HomeSecurityControl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeSecuritySystem.Test
{
    [TestClass]
    public class CommunicationUnitTest
    {        
        [TestMethod]
        public void CommunicationUnit_InformSecurity()
        {
            CommunicationUnit comms = new CommunicationUnit();
            comms.InformSecurity("Security alert.");
        }


        [TestMethod]
        public void ComminicationUnit_IsOn()
        {
            CommunicationUnit comms = new CommunicationUnit();
            Assert.IsTrue(comms.IsOn);
        }
    }
}
