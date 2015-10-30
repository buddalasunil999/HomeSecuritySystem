using HomeSecuritySystem.Comms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSecuritySystem
{
    public class CommunicationUnit : IComms
    {
        public bool IsOn
        {
            get
            {
                return true;
            }
        }

        public void InformSecurity(string detail)
        {

        }
    }
}
