using System;
using System.Timers;
using HomeSecurityControl;

namespace HomeSecuritySystem.Test
{
    public class TimerMock : ITimer
    {
        private bool _enabled;

        public bool Enabled
        {
            set
            {
                _enabled = value;
                ElapsedEventHandler onElapsed = Elapsed;
                onElapsed?.Invoke(this, new EventArgs() as ElapsedEventArgs);
            }
            get { return _enabled; }
        }
        public double Interval { set; get; }
        public event ElapsedEventHandler Elapsed;
    }
}
