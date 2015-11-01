using HomeSecuritySystem.Sensors;
using HomeSecuritySystem.Events;
using HomeSecuritySystem.Report;

namespace HomeSecurityControl
{
    public class MotionSensor : ISensor, IControllable
    {
        public MotionSensor(int id)
        {
            Id = id;
        }

        public bool Detected { get; private set; }

        public int Id { get; }

        public bool IsOn { get; private set; }

        public SensorType Type => SensorType.Motion;

        public event SensorDetectionStateChangeEvent OnDetectionStateChanged;
        
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
