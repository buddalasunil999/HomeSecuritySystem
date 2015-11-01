using HomeSecuritySystem.Events;
using HomeSecuritySystem.Report;
using HomeSecuritySystem.Sensors;

namespace HomeSecurityControl
{
    public class SmokeSensor : ISensor, IControllable
    {
        public int Id { get; }

        public SensorType Type { get; }

        public bool IsOn { get; private set; }

        public bool Detected { get; private set; }

        public event SensorDetectionStateChangeEvent OnDetectionStateChanged;

        public SmokeSensor(int id)
        {
            Id = id;
            Type = SensorType.Smoke;
        }

        public void SwitchOn()
        {
            IsOn = true;
        }

        public void SwitchOff()
        {
            IsOn = false;
        }

        public void Trigger()
        {
            Detected = true;
            OnDetectionStateChange();
        }

        public void ResetTrigger()
        {
            Detected = false;
            OnDetectionStateChange();
        }

        protected virtual void OnDetectionStateChange()
        {
            SensorDetectionStateChangeEvent handler = OnDetectionStateChanged;
            if (handler != null)
                handler(this);
        }
    }
}
