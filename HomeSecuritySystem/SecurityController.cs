using HomeSecuritySystem.Sensors;
using System;
using System.Collections.Generic;
using HomeSecuritySystem.Comms;
using HomeSecuritySystem.Alarm;
using HomeSecuritySystem.Power;
using HomeSecuritySystem.Display;
using HomeSecuritySystem.Base;
using HomeSecuritySystem.Report;
using Newtonsoft.Json;
using System.Timers;
using HomeSecuritySystem;

namespace HomeSecurityControl
{
    public class SecurityController : ControllerBase
    {
        private ICollection<ISensor> _sensors;
        private IComms _comms;
        private IPowerSupply _powerSupply;
        private IAlarm _alarm;
        private IDisplay _display;
        public ITimer SystemCheckTimer { get; set; }
        
        public SecurityController(ICollection<ISensor> sensors, IComms comms, IPowerSupply powerSupply,
            IAlarm alarm, IDisplay display) : this(sensors, comms, powerSupply, alarm, display, new TimerAdaper(3000))
        {
        }

        public SecurityController(ICollection<ISensor> sensors, IComms comms, IPowerSupply powerSupply,
            IAlarm alarm, IDisplay display, ITimer timer) : base(sensors, comms, powerSupply, alarm, display)
        {
            _sensors = sensors;
            _comms = comms;
            _powerSupply = powerSupply;
            _alarm = alarm;
            _display = display;

            foreach (ISensor sensor in _sensors)
            {
                _display.ShowSensorDetected(sensor.Id);
                sensor.OnDetectionStateChanged += Sensor_OnDetectionStateChanged;
            }

            powerSupply.OnNoPower += PowerSupply_OnNoPower;

            SystemCheck();

            SystemCheckTimer = timer;
            SystemCheckTimer.Elapsed += Timer_Elapsed;
            SystemCheckTimer.Enabled = true;
        }

        public override void SystemCheck()
        {
            var lowBatterySensors = new List<int>();

            foreach (ISensor sensor in _sensors)
            {
                var powredSensor = sensor as IPowered;
                if (powredSensor != null && !powredSensor.IsOn)
                {
                    _display.ShowSystemNotReady();
                    return;
                }

                var batteryPoweredSensor = sensor as IBatteryPowered;
                if (batteryPoweredSensor != null && batteryPoweredSensor.IsLowBattery)
                    lowBatterySensors.Add(sensor.Id);
            }

            if (!_alarm.IsOn)
            {
                _display.ShowSystemNotReady();
                return;
            }

            if (_powerSupply.IsLowBattery)
                _display.ShowPowerSupplyLowBattery();
            else if (lowBatterySensors.Count > 0)
                _display.ShowSensorLowBattery(lowBatterySensors);
            else
                _display.ShowSystemReady();
        }

        public override void ClearMemory()
        {
            _display.ClearSentReport();
        }

        public override void Disarm()
        {
            base.Disarm();

            _alarm.StopAlarm();
        }

        private void Sensor_OnDetectionStateChanged(ISensor sensor)
        {
            if (IsArmed && IsStay && sensor.Type != SensorType.Motion)
                return;

            NotifySystem(sensor);
        }

        private void PowerSupply_OnNoPower()
        {
            _display.ShowPowerSupplyLowBattery();
            var report = new Report
            {
                Type = ReportType.NoPower,
                Time = DateTime.Now
            };

            string details = ConvertToJson(report);
            _comms.InformSecurity(details);
            _display.ShowSentReport(details);
        }

        protected virtual void NotifySystem(ISensor sensor)
        {
            _alarm.SoundAlarm();
            _display.ShowAlarmSound();

            var report = new Report
            {
                SensorId = sensor.Id,
                SensorType = sensor.Type,
                Type = GetReportType(sensor.Type),
                Time = DateTime.Now
            };

            string details = ConvertToJson(report);
            _comms.InformSecurity(details);
            _display.ShowSentReport(details);
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            SystemCheck();
        }

        public static string ConvertToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T DeserializeJson<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        public static ReportType GetReportType(SensorType type)
        {
            switch (type)
            {
                case SensorType.Smoke:
                    return ReportType.Smoke;
                case SensorType.Gas:
                    return ReportType.Smoke;
                case SensorType.Motion:
                    return ReportType.Intrusion;
                default:
                    return ReportType.NoPower;
            }
        }
    }
}
