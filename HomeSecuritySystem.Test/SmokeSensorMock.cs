using HomeSecuritySystem.Sensors;
using System;
using HomeSecuritySystem.Events;
using HomeSecuritySystem.Report;
using HomeSecuritySystem.Base;

namespace HomeSecuritySystem.Test
{
    public class SmokeSensorMock : ISensor, IBatteryPowered
    {
        private bool _isOn;
        private bool _isLowBattery;

        public SmokeSensorMock(bool isOn)
        {
            _isOn = isOn;
        }

        public SmokeSensorMock(bool isOn, bool isLowBattery)
        {
            _isOn = isOn;
            _isLowBattery = isLowBattery;
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

        public bool IsLowBattery
        {
            get
            {
                return _isLowBattery;
            }
        }

        public bool IsOn
        {
            get
            {
                return _isOn;
            }
        }

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
