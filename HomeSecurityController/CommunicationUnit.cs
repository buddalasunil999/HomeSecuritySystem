using HomeSecuritySystem.Comms;

namespace HomeSecurityControl
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
