using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HomeSecuritySystem.Sensors;
using HomeSecuritySystem.Report;
using HomeSecurityControl;

namespace HomeSecuritySystem.Test
{
    [TestClass]
    public class SecurityControllerTest
    {
        private SecurityController _controller;
        private ICollection<ISensor> _sensors;
        private SmokeSensor _smokeSensor;
        private MotionSensor _motionSensor;
        private CommunicationUnit _comms;
        private PowerSupply _powerSupply;
        private SecurityAlarm _alarm;
        private PowerSupplyMock _lowBatteryPowerSupply;
        private CommunicationUnitMock _commsMock;
        private DisplayMock _display;

        [TestInitialize]
        public void Initialize()
        {
            _sensors = new List<ISensor>();
            _smokeSensor = new SmokeSensor(1);
            _motionSensor = new MotionSensor(2);
            _comms = new CommunicationUnit();
            _powerSupply = new PowerSupply();
            _alarm = new SecurityAlarm();
            _lowBatteryPowerSupply = new PowerSupplyMock(true);
            _commsMock = new CommunicationUnitMock(true);
            _display = new DisplayMock();

            _smokeSensor.SwitchOn();
            _motionSensor.SwitchOn();
            _alarm.SwitchOn();
        }

        [TestMethod]
        public void SystemCheck_WithNoSensors()
        {
            _controller = new SecurityController(_sensors, _comms, _powerSupply, _alarm, _display);

            Assert.IsTrue(_display.DisplayedItems.SystemReady);
        }

        [TestMethod]
        public void SystemCheck_WhenPoweredSensor_IsOff()
        {
            _sensors.Add(_smokeSensor);
            _smokeSensor.SwitchOff();

            _controller = new SecurityController(_sensors, _comms, _powerSupply, _alarm, _display);

            Assert.IsFalse(_display.DisplayedItems.SystemReady);
        }

        [TestMethod]
        public void SystemCheck_WhenAlarm_IsOff()
        {
            _alarm.SwitchOff();
            _sensors.Add(_smokeSensor);

            _controller = new SecurityController(_sensors, _comms, _powerSupply, _alarm, _display);

            Assert.IsFalse(_display.DisplayedItems.SystemReady);
        }

        [TestMethod]
        public void SystemCheck_WhenAlarm_IsOn()
        {
            _controller = new SecurityController(_sensors, _comms, _powerSupply, _alarm, _display);

            Assert.IsTrue(_display.DisplayedItems.SystemReady);
        }

        [TestMethod]
        public void SystemCheck_WhenPoweredSensor_IsOn()
        {
            _sensors.Add(_smokeSensor);

            _controller = new SecurityController(_sensors, _comms, _powerSupply, _alarm, _display);

            Assert.IsTrue(_display.DisplayedItems.SystemReady);
        }

        [TestMethod]
        public void SystemCheck_WhenPowerSupply_OnLowBattery()
        {
            _sensors.Add(_smokeSensor);

            _controller = new SecurityController(_sensors, _comms, _lowBatteryPowerSupply, _alarm, _display);

            Assert.IsTrue(_display.DisplayedItems.PowerSupplyLowBattery);
        }

        [TestMethod]
        public void SystemCheck_WhenPowerSupply_NotOnLowBattery()
        {
            _sensors.Add(_smokeSensor);

            _controller = new SecurityController(_sensors, _comms, _powerSupply, _alarm, _display);

            Assert.IsFalse(_display.DisplayedItems.PowerSupplyLowBattery);
        }

        [TestMethod]
        public void SystemCheck_WhenBatteryPoweredSensor_OnLowBattery()
        {
            var sensor = new BatteryPoweredSensorMock(true, true);
            _sensors.Add(sensor);

            _controller = new SecurityController(_sensors, _comms, _powerSupply, _alarm, _display);

            Assert.IsTrue(_display.DisplayedItems.LowBatterySensors.Count > 0);
            CollectionAssert.AllItemsAreUnique(_display.DisplayedItems.LowBatterySensors);
            CollectionAssert.Contains(_display.DisplayedItems.LowBatterySensors, sensor.Id);
        }

        [TestMethod]
        public void SystemCheck_WhenSensors_NotOnLowBattery()
        {
            _sensors.Add(_smokeSensor);

            _controller = new SecurityController(_sensors, _comms, _powerSupply, _alarm, _display);

            Assert.IsFalse(_display.DisplayedItems.LowBatterySensors.Count > 0);
        }
        
        [TestMethod]
        public void WhenArmed_TestDisplayStatus()
        {
            _controller = new SecurityController(_sensors, _comms, _powerSupply, _alarm, _display);

            _controller.Arm();
            Assert.IsTrue(_display.DisplayedItems.Armed);
            Assert.IsFalse(_display.DisplayedItems.Stay);
        }

        [TestMethod]
        public void WhenArmeStay_TestDisplayStatus()
        {
            _controller = new SecurityController(_sensors, _comms, _powerSupply, _alarm, _display);

            _controller.ArmStay();
            Assert.IsTrue(_display.DisplayedItems.Armed);
            Assert.IsTrue(_display.DisplayedItems.Stay);
        }

        [TestMethod]
        public void WhenArmed_And_NoSensorsDetected()
        {
            _sensors.Add(_smokeSensor);

            _controller = new SecurityController(_sensors, _comms, _powerSupply, _alarm, _display);

            _controller.Arm();
            Assert.IsFalse(_display.DisplayedItems.AlarmSound);
        }

        [TestMethod]
        public void WhenArmed_SensorsDetected_TestAlarm()
        {
            _sensors.Add(_smokeSensor);

            _controller = new SecurityController(_sensors, _comms, _powerSupply, _alarm, _display);

            _controller.Arm();
            _smokeSensor.Trigger();
            Assert.IsTrue(_alarm.IsActive);
            Assert.IsTrue(_display.DisplayedItems.AlarmSound);
        }

        [TestMethod]
        public void WhenArmed_SensorsDetected_TestSendReport()
        {
            _sensors.Add(_smokeSensor);

            _controller = new SecurityController(_sensors, _commsMock, _powerSupply, _alarm, _display);
            _controller.Arm();
            _smokeSensor.Trigger();
            Report.Report report = SecurityController.DeserializeJson<Report.Report>(_commsMock.Details);

            Assert.AreEqual(_smokeSensor.Id, report.SensorId);
            Assert.AreEqual(_smokeSensor.Type, report.SensorType);
            Assert.AreEqual(ReportType.Smoke, report.Type);
            Assert.AreEqual(_commsMock.Details, _display.DisplayedItems.ReportDetail);
        }

        [TestMethod]
        public void WhenArmStay_NonPerimeterSensorDetected()
        {
            _sensors.Add(_smokeSensor);
            _sensors.Add(_motionSensor);

            _controller = new SecurityController(_sensors, _comms, _powerSupply, _alarm, _display);
            _controller.ArmStay();
            _smokeSensor.Trigger();

            Assert.IsFalse(_display.DisplayedItems.AlarmSound);
        }

        [TestMethod]
        public void WhenArmStay_PerimeterSensorDetected()
        {
            _sensors.Add(_smokeSensor);
            _sensors.Add(_motionSensor);

            _controller = new SecurityController(_sensors, _comms, _powerSupply, _alarm, _display);

            _controller.ArmStay();
            _motionSensor.Trigger();

            Assert.IsTrue(_alarm.IsActive);
        }

        [TestMethod]
        public void WhenArmStay_PerimeterSensorDetected_TestSendReport()
        {
            _sensors.Add(_smokeSensor);
            _sensors.Add(_motionSensor);

            _controller = new SecurityController(_sensors, _commsMock, _powerSupply, _alarm, _display);

            _controller.ArmStay();
            _motionSensor.Trigger();
            Report.Report report = SecurityController.DeserializeJson<Report.Report>(_commsMock.Details);

            Assert.AreEqual(_motionSensor.Id, report.SensorId);
            Assert.AreEqual(_motionSensor.Type, report.SensorType);
            Assert.AreEqual(ReportType.Intrusion, report.Type);
            Assert.AreEqual(_commsMock.Details, _display.DisplayedItems.ReportDetail);
        }

        [TestMethod]
        public void WhenDisarmed_StopAlarm_ClearDisplay()
        {
            _sensors.Add(_smokeSensor);
            _sensors.Add(_motionSensor);

            _controller = new SecurityController(_sensors, _comms, _powerSupply, _alarm, _display);

            _controller.ArmStay();
            _motionSensor.Trigger();
            _controller.Disarm();

            Assert.IsFalse(_alarm.IsActive);
            Assert.IsFalse(_display.DisplayedItems.Armed);
            Assert.IsFalse(_display.DisplayedItems.AlarmSound);
        }

        [TestMethod]
        public void WhenNotArmed_SmokeSensorDetected()
        {
            _sensors.Add(_smokeSensor);
            _sensors.Add(_motionSensor);

            _controller = new SecurityController(_sensors, _comms, _powerSupply, _alarm, _display);
            _controller.Disarm();
            _smokeSensor.Trigger();

            Assert.IsTrue(_alarm.IsActive);
        }

        [TestMethod]
        public void WhenArmed_SmokeSensorDetected()
        {
            _sensors.Add(_smokeSensor);
            _sensors.Add(_motionSensor);

            _controller = new SecurityController(_sensors, _comms, _powerSupply, _alarm, _display);
            _controller.Arm();
            _smokeSensor.Trigger();

            Assert.IsTrue(_alarm.IsActive);
        }

        [TestMethod]
        public void WhenArmed_SmokeSensorDetected_TestSendReport()
        {
            _sensors.Add(_smokeSensor);
            _sensors.Add(_motionSensor);

            _controller = new SecurityController(_sensors, _commsMock, _powerSupply, _alarm, _display);
            _controller.Arm();
            _smokeSensor.Trigger();

            var report = SecurityController.DeserializeJson<Report.Report>(_commsMock.Details);
            Assert.AreEqual(_smokeSensor.Id, report.SensorId);
            Assert.AreEqual(_smokeSensor.Type, report.SensorType);
            Assert.AreEqual(ReportType.Smoke, report.Type);
            Assert.AreEqual(_commsMock.Details, _display.DisplayedItems.ReportDetail);
        }

        [TestMethod]
        public void TestPeriodic_SystemCheck()
        {
            _sensors.Add(_smokeSensor);
            _sensors.Add(_motionSensor);
            var timer = new TimerMock();
            bool elapsed = false;
            timer.Elapsed += (sender, e) => elapsed = true;
            timer.Enabled = true;

            _controller = new SecurityController(_sensors, _comms, _powerSupply, _alarm, _display, timer);

            Assert.IsTrue(elapsed);
            Assert.IsTrue(_display.DisplayedItems.SystemReady);
        }

        [TestMethod]
        public void WhenArmed_Display_StatesOfAllSensors()
        {
            _sensors.Add(_smokeSensor);
            _sensors.Add(_motionSensor);

            _controller = new SecurityController(_sensors, _comms, _powerSupply, _alarm, _display);
            _controller.Arm();

            CollectionAssert.Contains(_display.DisplayedItems.DetectedSensors, _smokeSensor.Id);
            CollectionAssert.Contains(_display.DisplayedItems.DetectedSensors, _motionSensor.Id);
        }

        [TestMethod]
        public void WhenNotArmed_Display_StatesOfAllSensors()
        {
            _sensors.Add(_smokeSensor);
            _sensors.Add(_motionSensor);

            _controller = new SecurityController(_sensors, _comms, _powerSupply, _alarm, _display);
            _controller.Disarm();

            CollectionAssert.Contains(_display.DisplayedItems.DetectedSensors, _smokeSensor.Id);
            CollectionAssert.Contains(_display.DisplayedItems.DetectedSensors, _motionSensor.Id);
        }

        [TestMethod]
        public void WhenPowerBlackOut_OperateOnBattery()
        {
            _controller = new SecurityController(_sensors, _comms, _powerSupply, _alarm, _display);
            _powerSupply.TriggerLowPower();

            Assert.IsTrue(_display.DisplayedItems.PowerSupplyLowBattery);
        }

        [TestMethod]
        public void WhenPowerBlackOut_TestReport()
        {
            _controller = new SecurityController(_sensors, _commsMock, _powerSupply, _alarm, _display);
            _powerSupply.TriggerLowPower();

            var report = SecurityController.DeserializeJson<Report.Report>(_commsMock.Details);
            Assert.AreEqual(ReportType.NoPower, report.Type);
            Assert.AreEqual(_commsMock.Details, _display.DisplayedItems.ReportDetail);
        }

        [TestMethod]
        public void WhenMemoryCleared_TestClear_OnDisplay()
        {
            _controller = new SecurityController(_sensors, _comms, _powerSupply, _alarm, _display);

            _controller.ClearMemory();

            Assert.IsTrue(string.IsNullOrEmpty(_display.DisplayedItems.ReportDetail));
            Assert.IsFalse(_display.DisplayedItems.AlarmSound);
            Assert.IsFalse(_display.DisplayedItems.Armed);
        }

        [TestMethod]
        public void TestReportType_WhenSensorType_IsSmoke()
        {
            Assert.AreEqual(ReportType.Smoke, SecurityController.GetReportType(SensorType.Smoke));
        }

        [TestMethod]
        public void TestReport_TypeWhenSensorType_IsGas()
        {
            Assert.AreEqual(ReportType.Smoke, SecurityController.GetReportType(SensorType.Gas));
        }

        [TestMethod]
        public void TestReportType_WhenSensorType_IsMotion()
        {
            Assert.AreEqual(ReportType.Intrusion, SecurityController.GetReportType(SensorType.Motion));
        }

        [TestMethod]
        public void TestReportType_WhenSensorType_IsOther()
        {
            Assert.AreEqual(ReportType.NoPower, SecurityController.GetReportType(SensorType.Other));
        }
    }
}