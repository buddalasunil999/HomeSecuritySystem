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
        SmokeSensor smokeSensor = new SmokeSensor(1);
        MotionSensor motionSensor = new MotionSensor(2);
        CommunicationUnit comms = new CommunicationUnit();
        PowerSupply powerSupply = new PowerSupply();
        SecurityAlarm alarm = new SecurityAlarm();
        PowerSupplyMock lowBatteryPowerSupply = new PowerSupplyMock(true);
        CommunicationUnitMock commsMock = new CommunicationUnitMock();
        DisplayMock display = new DisplayMock();

        [TestInitialize]
        public void Initialize()
        {
            smokeSensor.SwitchOn();
            motionSensor.SwitchOn();
        }

        [TestMethod]
        public void SystemCheck_WithNoSensors()
        {
            controller = new SecurityController(sensors, comms, powerSupply, alarm, display);

            controller.SystemCheck();
            Assert.IsTrue(display.DisplayedItems.SystemReady);
        }

        [TestMethod]
        public void SystemCheck_WhenSensorFailing()
        {
            sensors.Add(new SmokeSensorMock(false));

            controller = new SecurityController(sensors, comms, powerSupply, alarm, display);

            controller.SystemCheck();
            Assert.IsFalse(display.DisplayedItems.SystemReady);
        }

        [TestMethod]
        public void SystemCheck_WhenSensorsWorking()
        {
            sensors.Add(smokeSensor);

            controller = new SecurityController(sensors, comms, powerSupply, alarm, display);

            controller.SystemCheck();
            Assert.IsTrue(display.DisplayedItems.SystemReady);
        }

        [TestMethod]
        public void SystemCheck_WhenPowerSupplyOnLowBattery()
        {
            sensors.Add(smokeSensor);

            controller = new SecurityController(sensors, comms, lowBatteryPowerSupply, alarm, display);

            controller.SystemCheck();
            Assert.IsTrue(display.DisplayedItems.PowerSupplyLowBattery);
        }

        [TestMethod]
        public void SystemCheck_WhenPowerSupplyNotOnLowBattery()
        {
            sensors.Add(smokeSensor);

            controller = new SecurityController(sensors, comms, powerSupply, alarm, display);

            controller.SystemCheck();
            Assert.IsFalse(display.DisplayedItems.PowerSupplyLowBattery);
        }

        [TestMethod]
        public void SystemCheck_WhenSensorsOnLowBattery()
        {
            sensors.Add(new SmokeSensorMock(true, true));

            controller = new SecurityController(sensors, comms, powerSupply, alarm, display);

            controller.SystemCheck();
            Assert.IsTrue(display.DisplayedItems.LowBatterySensors.Count > 0);
            Assert.IsTrue(display.DisplayedItems.LowBatterySensors.Contains(1));
        }

        [TestMethod]
        public void SystemCheck_WhenSensorsAreNotOnLowBattery()
        {
            sensors.Add(smokeSensor);

            controller = new SecurityController(sensors, comms, powerSupply, alarm, display);

            controller.SystemCheck();
            Assert.IsFalse(display.DisplayedItems.LowBatterySensors.Count > 0);
        }

        [TestMethod]
        public void WhenArmed_NoSensorsDetected()
        {
            sensors.Add(smokeSensor);

            controller = new SecurityController(sensors, comms, powerSupply, alarm, display);

            controller.Arm();
            Assert.IsFalse(display.DisplayedItems.AlarmSound);
        }

        [TestMethod]
        public void WhenArmed_SensorsDetected()
        {
            sensors.Add(smokeSensor);

            controller = new SecurityController(sensors, comms, powerSupply, alarm, display);

            controller.Arm();
            smokeSensor.Trigger();
            Assert.IsTrue(display.DisplayedItems.AlarmSound);
        }

        [TestMethod]
        public void WhenArmed_SensorsDetected_SoundAlarm()
        {
            sensors.Add(smokeSensor);

            controller = new SecurityController(sensors, comms, powerSupply, alarm, display);

            controller.Arm();
            smokeSensor.Trigger();
            Assert.IsTrue(alarm.IsActive);
            Assert.IsTrue(display.DisplayedItems.AlarmSound);
        }

        [TestMethod]
        public void WhenArmed_SensorsDetected_SendReport()
        {
            sensors.Add(smokeSensor);

            controller = new SecurityController(sensors, commsMock, powerSupply, alarm, display);

            controller.Arm();
            smokeSensor.Trigger();
            Report.Report report = SecurityController.DeserializeJSON<Report.Report>(commsMock.Details);
            Assert.AreEqual(smokeSensor.Id, report.SensorId);
            Assert.AreEqual(smokeSensor.Type, report.SensorType);
            Assert.AreEqual(ReportType.Smoke, report.Type);

            Assert.AreEqual(commsMock.Details, display.DisplayedItems.ReportDetail);
        }

        [TestMethod]
        public void WhenArmStay_NonPerimeterSensorDetected()
        {
            sensors.Add(smokeSensor);
            sensors.Add(motionSensor);

            controller = new SecurityController(sensors, comms, powerSupply, alarm, display);

            controller.ArmStay();
            smokeSensor.Trigger();

            Assert.IsFalse(display.DisplayedItems.AlarmSound);
        }

        [TestMethod]
        public void WhenArmStay_PerimeterSensorDetected()
        {
            sensors.Add(smokeSensor);
            sensors.Add(motionSensor);

            controller = new SecurityController(sensors, comms, powerSupply, alarm, display);

            controller.ArmStay();
            motionSensor.Trigger();

            Assert.IsTrue(alarm.IsActive);
        }

        [TestMethod]
        public void WhenDisarmed_StopAlarm()
        {
            sensors.Add(smokeSensor);
            sensors.Add(motionSensor);

            controller = new SecurityController(sensors, comms, powerSupply, alarm, display);

            controller.ArmStay();
            motionSensor.Trigger();
            controller.Disarm();

            Assert.IsFalse(alarm.IsActive);
        }

        [TestMethod]
        public void WhenNotArmed_SmokeSensorDetected()
        {
            sensors.Add(smokeSensor);
            sensors.Add(motionSensor);

            controller = new SecurityController(sensors, comms, powerSupply, alarm, display);
            controller.Disarm();
            smokeSensor.Trigger();

            Assert.IsTrue(alarm.IsActive);
        }

        [TestMethod]
        public void WhenArmed_Display_StatesOfAllSensors()
        {
            sensors.Add(smokeSensor);
            sensors.Add(motionSensor);

            controller = new SecurityController(sensors, comms, powerSupply, alarm, display);
            controller.Arm();

            Assert.IsTrue(display.DisplayedItems.DetectedSensors.Contains(smokeSensor.Id));
            Assert.IsTrue(display.DisplayedItems.DetectedSensors.Contains(motionSensor.Id));
        }

        [TestMethod]
        public void WhenNotArmed_Display_StatesOfAllSensors()
        {
            sensors.Add(smokeSensor);
            sensors.Add(motionSensor);

            controller = new SecurityController(sensors, comms, powerSupply, alarm, display);
            controller.Disarm();

            Assert.IsTrue(display.DisplayedItems.DetectedSensors.Contains(smokeSensor.Id));
            Assert.IsTrue(display.DisplayedItems.DetectedSensors.Contains(motionSensor.Id));
        }

        [TestMethod]
        public void WhenPowerBlackOut_OperateOnBattery()
        {
            controller = new SecurityController(sensors, comms, powerSupply, alarm, display);
            powerSupply.TriggerLowPower();

            Assert.IsTrue(display.DisplayedItems.PowerSupplyLowBattery);
        }

        [TestMethod]
        public void WhenReportGenerated_Display()
        {
            controller = new SecurityController(sensors, commsMock, powerSupply, alarm, display);
            powerSupply.TriggerLowPower();

            var report = SecurityController.DeserializeJSON<Report.Report>(commsMock.Details);
            Assert.AreEqual(ReportType.NoPower, report.Type);
            Assert.AreEqual(commsMock.Details, display.DisplayedItems.ReportDetail);
        }

        [TestMethod]
        public void WhenMemoryCleared_ClearReport_OnDisplay()
        {
            controller = new SecurityController(sensors, commsMock, powerSupply, alarm, display);
            controller.ClearMemory();
            Assert.IsTrue(string.IsNullOrEmpty(display.DisplayedItems.ReportDetail));
        }
    }
}