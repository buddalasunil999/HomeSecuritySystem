using HomeSecuritySystem.Alarm;

namespace HomeSecurityControl
{
    public class SecurityAlarm : IAlarm
    {
        public bool IsActive { get; private set; }

        public bool IsOn { get; private set; }

        public void SoundAlarm()
        {
            IsActive = true;
        }

        public void StopAlarm()
        {
            IsActive = false;
        }

        public void SwitchOn()
        {
            IsOn = true;
        }

        public void SwitchOff()
        {
            IsOn = false;
        }
    }
}
