using HomeSecuritySystem.Comms;

namespace HomeSecuritySystem.Test
{
    public class CommunicationUnitMock : IComms
    {
        public bool IsOn { get; }

        public string Details { get; private set; }

        public void InformSecurity(string detail)
        {
            Details = detail;
        }

        public CommunicationUnitMock(bool isOn)
        {
            IsOn = isOn;
        }
    }
}
