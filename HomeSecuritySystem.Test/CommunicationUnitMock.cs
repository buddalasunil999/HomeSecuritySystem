using HomeSecuritySystem.Comms;
using System;
namespace HomeSecuritySystem.Test
{
    public class CommunicationUnitMock : IComms
    {
        private string _details;

        public bool IsOn
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Details
        {
            get
            {
                return _details;
            }
        }

        public void InformSecurity(string detail)
        {
            _details = detail;
        }
    }
}
