using HomeSecuritySystem.Alarm;

namespace HomeSecurityControl
{
    public class SecurityAlarm : IAlarm
    {
        protected bool _isActive;
        protected bool _isOn;

        public bool IsActive
        {
            get
            {
                return _isActive;
            }
        }

        public bool IsOn
        {
            get
            {
                return _isOn;
            }
        }

        public void SoundAlarm()
        {
            _isActive = true;
        }

        public void StopAlarm()
        {
            _isActive = false;
        }

        public void SwitchOn()
        {
            _isOn = true;
        }

        public void SwitchOff()
        {
            _isOn = false;
        }
    }
}
