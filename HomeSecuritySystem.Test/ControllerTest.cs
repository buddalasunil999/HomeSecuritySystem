using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HomeSecuritySystem.Sensors;

namespace HomeSecuritySystem.Test
{
    [TestClass]
    public class ControllerTest
    {
        SecurityController controller;
        ICollection<ISensor> sensors = new List<ISensor>();
        DisplayMock display = new DisplayMock();

        [TestInitialize]
        public void Initialize()
        {
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
            sensors.Add(new SmokeSensor());

            controller = new SecurityController(sensors, new CommunicationUnit(), new PowerSupply(),
                new SecurityAlarm(), display);

            controller.SystemCheck();
            Assert.IsTrue(display.DisplayedItems.SystemReady);
        }

        [TestMethod]
        public void TestSystemCheckWhenPowerSupplyOnLowBattery()
        {
            sensors.Add(new SmokeSensor());

            controller = new SecurityController(sensors, new CommunicationUnit(), new PowerSupplyMock(true),
                new SecurityAlarm(), display);

            controller.SystemCheck();
            Assert.IsTrue(display.DisplayedItems.PowerSupplyLowBattery);
        }

        [TestMethod]
        public void TestSystemCheckWhenPowerSupplyNotOnLowBattery()
        {
            sensors.Add(new SmokeSensor());

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
        }

        [TestMethod]
        public void TestSystemCheckWhenSensorsAreNotOnLowBattery()
        {
            sensors.Add(new SmokeSensor());

            controller = new SecurityController(sensors, new CommunicationUnit(), new PowerSupply(),
                new SecurityAlarm(), display);

            controller.SystemCheck();
            Assert.IsFalse(display.DisplayedItems.LowBatterySensors.Count > 0);
        }
    }
}
