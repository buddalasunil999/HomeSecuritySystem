using HomeSecuritySystem.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeSecuritySystem.Events;
using HomeSecuritySystem.Report;

namespace HomeSecuritySystem
{
    public class MotionSensor : ISensor
    {
        public bool Detected
        {
            get
            {
                return true;
            }
        }

        public int Id
        {
            get
            {
                return 2;
            }
        }

        public bool IsOn
        {
            get
            {
                return true;
            }
        }

        public SensorType Type
        {
            get
            {
                return SensorType.Motion;
            }
        }

        public event SensorDetectionStateChangeEvent OnDetectionStateChanged;
    }
}
