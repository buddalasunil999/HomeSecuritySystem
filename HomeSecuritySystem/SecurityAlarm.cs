using HomeSecuritySystem.Alarm;

namespace HomeSecurityControl
{
    public class SecurityAlarm : IAlarm
    {
        private bool _isActive;
        private bool _isOn;

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
    }
}
