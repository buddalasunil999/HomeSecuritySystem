using HomeSecuritySystem.Sensors;
using System;
using HomeSecuritySystem.Events;
using HomeSecuritySystem.Report;
using HomeSecuritySystem.Base;

namespace HomeSecuritySystem.Test
{
    public class SmokeSensorMock : ISensor, IBatteryPowered
    {
        public SmokeSensorMock(bool isOn)
        {
            IsOn = isOn;
        }

        public SmokeSensorMock(bool isOn, bool isLowBattery)
        {
            IsOn = isOn;
            IsLowBattery = isLowBattery;
        }

        public bool Detected
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Id
        {
            get
            {
                return 1;
            }
        }

        public bool IsLowBattery { get; }

        public bool IsOn { get; }

        public SensorType Type
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public event SensorDetectionStateChangeEvent OnDetectionStateChanged;
    }
}
