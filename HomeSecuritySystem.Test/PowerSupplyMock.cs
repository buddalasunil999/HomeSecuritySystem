using HomeSecuritySystem.Power;
using HomeSecuritySystem.Events;

namespace HomeSecuritySystem.Test
{
    public class PowerSupplyMock : IPowerSupply
    {
        public bool IsLowBattery { get; }

        public bool IsOn
        {
            get
            {
                return true;
            }
        }

        public PowerSupplyMock(bool isLowBattery)
        {
            IsLowBattery = isLowBattery;
        }

        public event NoPowerEvent OnNoPower;
    }
}
