using HomeSecuritySystem.Power;
using HomeSecuritySystem.Events;

namespace HomeSecuritySystem.Test
{
    public class PowerSupplyMock : IPowerSupply
    {
        bool _isLowBattery;

        public bool IsLowBattery
        {
            get
            {
                return true;
            }
        }

        public bool IsOn
        {
            get
            {
                return true;
            }
        }

        public PowerSupplyMock(bool isLowBattery)
        {
            _isLowBattery = isLowBattery;
        }

        public event NoPowerEvent OnNoPower;
    }
}
