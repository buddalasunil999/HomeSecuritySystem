using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HomeSecuritySystem.Sensors;
using HomeSecuritySystem.Report;

namespace HomeSecuritySystem.Test
{
    [TestClass]
    public class ControllerTest
    {
        SecurityController controller;
        ICollection<ISensor> sensors = new List<ISensor>();
        DisplayMock display = new DisplayMock();
        SmokeSensor smokeSensor = new SmokeSensor(1);

        [TestInitialize]
        public void Initialize()
        {
            smokeSensor.SwitchOn();
        }

        [TestMethod]
        public void TestSystemCheckWithNoSensors()
        {
            controller = new SecurityController(sensors, new CommunicationUnit(), new PowerSupply(),
                new SecurityAlarm(), display);

            controller.SystemCheck();
            Assert.IsTrue(display.DisplayedItems.SystemReady);
        }

        [TestMethod]
        public void TestSystemCheckWhenSensorFailing()
        {
            sensors.Add(new SmokeSensorMock(false));

            controller = new SecurityController(sensors, new CommunicationUnit(), new PowerSupply(),
                new SecurityAlarm(), display);

            controller.SystemCheck();
            Assert.IsFalse(display.DisplayedItems.SystemReady);
        }

        [TestMethod]
        public void TestSystemCheckWhenSensorsWorking()
        {
            sensors.Add(smokeSensor);

            controller = new SecurityController(sensors, new CommunicationUnit(), new PowerSupply(),
                new SecurityAlarm(), display);

            controller.SystemCheck();
            Assert.IsTrue(display.DisplayedItems.SystemReady);
        }

        [TestMethod]
        public void TestSystemCheckWhenPowerSupplyOnLowBattery()
        {
            sensors.Add(smokeSensor);

            controller = new SecurityController(sensors, new CommunicationUnit(), new PowerSupplyMock(true),
                new SecurityAlarm(), display);

            controller.SystemCheck();
            Assert.IsTrue(display.DisplayedItems.PowerSupplyLowBattery);
        }

        [TestMethod]
        public void TestSystemCheckWhenPowerSupplyNotOnLowBattery()
        {
            sensors.Add(smokeSensor);

            controller = new SecurityController(sensors, new CommunicationUnit(), new PowerSupply(),
                new SecurityAlarm(), display);

            controller.SystemCheck();
            Assert.IsFalse(display.DisplayedItems.PowerSupplyLowBattery);
        }

        [TestMethod]
        public void TestSystemCheckWhenSensorsOnLowBattery()
        {
            sensors.Add(new SmokeSensorMock(true, true));

            controller = new SecurityController(sensors, new CommunicationUnit(), new PowerSupply(),
                new SecurityAlarm(), display);

            controller.SystemCheck();
            Assert.IsTrue(display.DisplayedItems.LowBatterySensors.Count > 0);
            Assert.IsTrue(display.DisplayedItems.LowBatterySensors.Contains(1));
        }

        [TestMethod]
        public void TestSystemCheckWhenSensorsAreNotOnLowBattery()
        {
            sensors.Add(smokeSensor);

            controller = new SecurityController(sensors, new CommunicationUnit(), new PowerSupply(),
                new SecurityAlarm(), display);

            controller.SystemCheck();
            Assert.IsFalse(display.DisplayedItems.LowBatterySensors.Count > 0);
        }

        [TestMethod]
        public void TestWhenArmedNoSensorsDetected()
        {
            sensors.Add(smokeSensor);

            controller = new SecurityController(sensors, new CommunicationUnit(), new PowerSupply(),
                new SecurityAlarm(), display);

            controller.Arm();
            Assert.IsTrue(display.DisplayedItems.DetectedSensors.Count == 0);
        }

        [TestMethod]
        public void TestWhenArmedSensorsDetected()
        {
            sensors.Add(smokeSensor);

            controller = new SecurityController(sensors, new CommunicationUnit(), new PowerSupply(),
                new SecurityAlarm(), display);

            controller.Arm();
            smokeSensor.Trigger();
            Assert.IsTrue(display.DisplayedItems.DetectedSensors.Count > 0);
            Assert.IsTrue(display.DisplayedItems.DetectedSensors.Contains(smokeSensor.Id));
        }

        [TestMethod]
        public void TestWhenArmedSensorsDetectedSoundAlarm()
        {
            sensors.Add(smokeSensor);
            SecurityAlarm alarm = new SecurityAlarm();
            controller = new SecurityController(sensors, new CommunicationUnit(), new PowerSupply(),
                alarm, display);

            controller.Arm();
            smokeSensor.Trigger();
            Assert.IsTrue(alarm.IsActive);
        }

        [TestMethod]
        public void TestWhenArmedSensorsDetectedSendReport()
        {
            sensors.Add(smokeSensor);
            CommunicationUnitMock comms = new CommunicationUnitMock();

            controller = new SecurityController(sensors, comms, new PowerSupply(),
                new SecurityAlarm(), display);

            controller.Arm();
            smokeSensor.Trigger();
            Report.Report report = SecurityController.DeserializeJSON<Report.Report>(comms.Details);
            Assert.AreEqual(smokeSensor.Id, report.SensorId);
            Assert.AreEqual(smokeSensor.Type, report.SensorType);
            Assert.AreEqual(ReportType.Smoke, report.Type);
        }
    }
}
