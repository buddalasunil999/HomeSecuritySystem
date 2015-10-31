using HomeSecuritySystem.Comms;

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
