using HomeSecuritySystem.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeSecuritySystem.Events;
using HomeSecuritySystem.Report;
using HomeSecuritySystem.Comms;
using HomeSecuritySystem.Alarm;
using HomeSecuritySystem.Power;
using HomeSecuritySystem.Display;
using HomeSecuritySystem.Base;

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
        }

        public override void ClearMemory()
        {
            throw new NotImplementedException();
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
    }
}
