using HomeSecuritySystem.Display;
using System;
using System.Collections.Generic;

namespace HomeSecuritySystem
{
    public class SystemDisplay : IDisplay
    {
        private DisplayedItems _displayedItems;

        public DisplayedItems DisplayedItems
        {
            get { return _displayedItems; }
        }

        public void ClearAlarmSound()
        {
            throw new NotImplementedException();
        }

        public void ClearSensorDetected(int id)
        {
            throw new NotImplementedException();
        }

        public void ClearSentReport()
        {
            throw new NotImplementedException();
        }

        public void ClearSystemArmed()
        {
            throw new NotImplementedException();
        }

        public void ShowAlarmSound()
        {
            throw new NotImplementedException();
        }

        public void ShowPowerSupplyLowBattery()
        {
            throw new NotImplementedException();
        }

        public void ShowSensorDetected(int id)
        {
            throw new NotImplementedException();
        }

        public void ShowSensorLowBattery(ICollection<int> ids)
        {
            throw new NotImplementedException();
        }

        public void ShowSentReport(string reportDetail)
        {
            throw new NotImplementedException();
        }

        public void ShowSystemArmed()
        {
            throw new NotImplementedException();
        }

        public void ShowSystemArmedStay()
        {
            throw new NotImplementedException();
        }

        public void ShowSystemNotReady()
        {
            throw new NotImplementedException();
        }

        public void ShowSystemReady()
        {
            throw new NotImplementedException();
        }
    }
}
