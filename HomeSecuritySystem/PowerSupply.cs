using HomeSecuritySystem.Power;
using HomeSecuritySystem.Events;

namespace HomeSecuritySystem
{
    public class PowerSupply : IPowerSupply
    {
        private bool _isLowBattery;
        private bool _isOn;

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

        public event NoPowerEvent OnNoPower;

        protected virtual void OnNoPowerEvent()
        {
            NoPowerEvent handler = OnNoPower;
            if (handler != null)
                handler();
        }

        public void SwitchOn()
        {
            _isOn = true;
        }

        public void SwitchOff()
        {
            _isOn = false;
        }

        public void TriggerLowPower()
        {
            _isLowBattery = true;
            OnNoPowerEvent();
        }
        
        public void ResetLowPower()
        {
            _isLowBattery = false;
        }
    }
}
