using HomeSecuritySystem.Power;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                throw new NotImplementedException();
            }
        }

        public PowerSupplyMock(bool isLowBattery)
        {
            _isLowBattery = isLowBattery;
        }

        public event NoPowerEvent OnNoPower;
    }
}
