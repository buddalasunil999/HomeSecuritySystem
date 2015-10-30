using HomeSecuritySystem.Events;
using HomeSecuritySystem.Report;
using HomeSecuritySystem.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSecuritySystem
{
    public class SmokeSensor : ISensor
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
                return 1;
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
                return SensorType.Smoke;
            }
        }

        public event SensorDetectionStateChangeEvent OnDetectionStateChanged;
    }
}
