using HomeSecuritySystem.Power;
using HomeSecuritySystem.Events;

namespace HomeSecurityControl
{
    public class PowerSupply : IPowerSupply
    {
        public bool IsLowBattery { get; private set; }

        public bool IsOn { get; private set; }

        public event NoPowerEvent OnNoPower;

        protected virtual void OnNoPowerEvent()
        {
            NoPowerEvent handler = OnNoPower;
            if (handler != null)
                handler();
        }

        public void SwitchOn()
        {
            IsOn = true;
        }

        public void SwitchOff()
        {
            IsOn = false;
        }

        public void TriggerLowPower()
        {
            IsLowBattery = true;
            OnNoPowerEvent();
        }
        
        public void ResetLowPower()
        {
            IsLowBattery = false;
        }
    }
}
