using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeSecuritySystem.Report;
using HomeSecurityControl;

namespace HomeSecuritySystem.Test
{
    [TestClass]
    public class ReportTest
    {
        [TestMethod]
        public void TestReportTypeWhenSensorTypeIsSmoke()
        {
            Assert.AreEqual(ReportType.Smoke, SecurityController.GetReportType(SensorType.Smoke));
        }

        [TestMethod]
        public void TestReportTypeWhenSensorTypeIsGas()
        {
            Assert.AreEqual(ReportType.Smoke, SecurityController.GetReportType(SensorType.Gas));
        }

        [TestMethod]
        public void TestReportTypeWhenSensorTypeIsMotion()
        {
            Assert.AreEqual(ReportType.Intrusion, SecurityController.GetReportType(SensorType.Motion));
        }

        [TestMethod]
        public void TestReportTypeWhenSensorTypeIsOther()
        {
            Assert.AreEqual(ReportType.NoPower, SecurityController.GetReportType(SensorType.Other));
        }
    }
}
