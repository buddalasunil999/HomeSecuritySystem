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

namespace HomeSecuritySystem
{
    public class SecurityController : ControllerBase
    {
        protected ICollection<ISensor> _sensors;
        protected IComms _comms;
        protected IPowerSupply _powerSupply;
        protected IAlarm _alarm;
        protected IDisplay _display;

        public SecurityController(ICollection<ISensor> sensors, IComms comms, IPowerSupply powerSupply,
            IAlarm alarm, IDisplay display)
            : base(sensors, comms, powerSupply, alarm, display)
        {
            _sensors = sensors;
            _comms = comms;
            _powerSupply = powerSupply;
            _alarm = alarm;
            _display = display;

            foreach (ISensor sensor in _sensors)
            {
                sensor.OnDetectionStateChanged += Sensor_OnDetectionStateChanged;
            }
        }
        
        public override void SystemCheck()
        {
            List<int> lowBatterySensors = new List<int>();

            foreach (ISensor sensor in _sensors)
            {
                IPowered powredSensor = sensor as IPowered;
                if (powredSensor != null && !powredSensor.IsOn)
                {
                    _display.ShowSystemNotReady();
                    return;
                }

                IBatteryPowered batteryPoweredSensor = sensor as IBatteryPowered;
                if (batteryPoweredSensor != null && batteryPoweredSensor.IsLowBattery)
                    lowBatterySensors.Add(sensor.Id);
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
            throw new NotImplementedException();
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

            NotifySecurity(sensor);
        }

        protected virtual void NotifySecurity(ISensor sensor)
        {
            _display.ShowSensorDetected(sensor.Id);
            _alarm.SoundAlarm();
            _display.ShowAlarmSound();

            Report.Report report = new Report.Report();
            report.SensorId = sensor.Id;
            report.SensorType = sensor.Type;
            report.Type = GetReportType(sensor.Type);
            report.Time = DateTime.Now;

            _comms.InformSecurity(ConvertToJSON(report));
        }

        public static string ConvertToJSON(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T DeserializeJSON<T>(string value)
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
