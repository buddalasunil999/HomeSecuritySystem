namespace HomeSecuritySystem
{
    interface IControllable
    {
        void SwitchOn();
        void SwitchOff();
        void Trigger();
        void ResetTrigger();
    }
}
