using HomeSecuritySystem.Sensors;
using System;
using HomeSecuritySystem.Events;
using HomeSecuritySystem.Report;
using HomeSecuritySystem.Base;

namespace HomeSecuritySystem.Test
{
    public class BatteryPoweredSensorMock : ISensor, IBatteryPowered
    {
        public BatteryPoweredSensorMock(bool isOn)
        {
            IsOn = isOn;
        }

        public BatteryPoweredSensorMock(bool isOn, bool isLowBattery)
        {
            IsOn = isOn;
            IsLowBattery = isLowBattery;
        }

        public bool Detected { get; }

        public int Id
        {
            get
            {
                return 10;
            }
        }

        public bool IsLowBattery { get; }

        public bool IsOn { get; }

        public SensorType Type
        {
            get
            {
                return SensorType.Gas;
            }
        }

        public event SensorDetectionStateChangeEvent OnDetectionStateChanged;
    }
}
