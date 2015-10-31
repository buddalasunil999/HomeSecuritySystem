using HomeSecuritySystem.Events;
using HomeSecuritySystem.Report;
using HomeSecuritySystem.Sensors;

namespace HomeSecuritySystem
{
    public class SmokeSensor : ISensor, IControllable
    {
        private int _id;
        private SensorType _type;
        private bool _isOn;
        private bool _detected;

        public int Id
        {
            get
            {
                return _id;
            }
        }

        public SensorType Type
        {
            get
            {
                return _type;
            }
        }

        public bool IsOn
        {
            get
            {
                return _isOn;
            }
        }

        public bool Detected
        {
            get
            {
                return _detected;
            }
        }

        public event SensorDetectionStateChangeEvent OnDetectionStateChanged;

        public SmokeSensor(int id)
        {
            _id = id;
            _type = SensorType.Smoke;
        }

        public void SwitchOn()
        {
            _isOn = true;
        }

        public void SwitchOff()
        {
            _isOn = false;
        }

        public void Trigger()
        {
            _detected = true;
            OnDetectionStateChange();
        }

        public void ResetTrigger()
        {
            _detected = false;
            OnDetectionStateChange();
        }

        protected virtual void OnDetectionStateChange()
        {
            SensorDetectionStateChangeEvent handler = OnDetectionStateChanged;
            if (handler != null)
                handler(this);
        }
    }
}
