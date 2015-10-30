using HomeSecuritySystem.Power;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeSecuritySystem.Events;

namespace HomeSecuritySystem
{
    public class PowerSupply : IPowerSupply
    {
        public PowerSupply()
        {
        }

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

        public event NoPowerEvent OnNoPower;
    }
}
