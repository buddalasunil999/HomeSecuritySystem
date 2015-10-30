using HomeSecuritySystem.Alarm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSecuritySystem
{
    public class SecurityAlarm : IAlarm
    {
        public bool IsActive
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

        public void SoundAlarm()
        {
        }

        public void StopAlarm()
        {
        }
    }
}
