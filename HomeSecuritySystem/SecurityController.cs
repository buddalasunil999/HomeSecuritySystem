using HomeSecuritySystem.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeSecuritySystem.Events;
using HomeSecuritySystem.Report;
using HomeSecuritySystem.Comms;
using HomeSecuritySystem.Alarm;

namespace HomeSecuritySystem
{
    public class SecurityController
    {
        public SecurityController()
        {
        }

        public bool IsSystemReady()
        {
            return true;
        }
    }
}
