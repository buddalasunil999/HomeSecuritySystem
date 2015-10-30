using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeSecuritySystem.Test
{
    [TestClass]
    public class CommunicationUnitTest
    {        
        [TestMethod]
        public void TestInformSecurity()
        {
            CommunicationUnit comms = new CommunicationUnit();
            comms.InformSecurity("Security alert.");
        }


        [TestMethod]
        public void TestIsOn()
        {
            CommunicationUnit comms = new CommunicationUnit();
            Assert.IsTrue(comms.IsOn);
        }
    }
}
