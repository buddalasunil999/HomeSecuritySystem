using HomeSecuritySystem.Comms;
using System;
namespace HomeSecuritySystem.Test
{
    public class CommunicationUnitMock : IComms
    {
        public bool IsOn
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Details { get; private set; }

        public void InformSecurity(string detail)
        {
            Details = detail;
        }
    }
}
