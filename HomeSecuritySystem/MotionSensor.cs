using HomeSecuritySystem.Sensors;
using HomeSecuritySystem.Events;
using HomeSecuritySystem.Report;

namespace HomeSecuritySystem
{
    public class MotionSensor : ISensor, IControllable
    {
        private int _id;
        private bool _isOn;
        private bool _detected;

        public MotionSensor(int id)
        {
            _id = id;
        }

        public bool Detected
        {
            get
            {
                return _detected;
            }
        }

        public int Id
        {
            get
            {
                return _id;
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
                return SensorType.Motion;
            }
        }

        public event SensorDetectionStateChangeEvent OnDetectionStateChanged;
        
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
