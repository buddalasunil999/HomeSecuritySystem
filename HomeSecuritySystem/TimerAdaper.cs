using System.Timers;

namespace HomeSecurityControl
{
    public interface ITimer
    {
        double Interval { get; set; }
        bool Enabled { get; set; }
        event ElapsedEventHandler Elapsed;
    }

    public class TimerAdaper : Timer, ITimer
    {
        public TimerAdaper(double interval) : base(interval)
        {
        }
    }
}
