namespace HomeSecuritySystem
{
    public interface IControllable
    {
        void SwitchOn();
        void SwitchOff();
        void Trigger();
        void ResetTrigger();
    }
}
