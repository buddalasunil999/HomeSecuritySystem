using HomeSecuritySystem;
using HomeSecuritySystem.Display;
using System.Collections.Generic;
using System;

namespace HomeSecurityControl
{
    public class SystemDisplay : IDisplay
    {
        private DisplayedItems _displayedItems;

        public DisplayedItems DisplayedItems
        {
            get { return _displayedItems; }
        }

        public event EventHandler<MessageAddedArgs> MessageAdded;

        public SystemDisplay()
        {
            _displayedItems.DetectedSensors = new List<int>();
            _displayedItems.LowBatterySensors = new List<int>();
            _displayedItems.PowerSupplyLowBattery = false;
            _displayedItems.AlarmSound = false;
            _displayedItems.Armed = false;
            _displayedItems.Stay = false;
            _displayedItems.SystemReady = false;
        }

        public void ShowSystemReady()
        {
            _displayedItems.SystemReady = true;
            SetMessage("System ready");
        }

        public void ShowSystemNotReady()
        {
            _displayedItems.SystemReady = false;
            SetMessage("System not ready");
        }

        public void ShowSensorDetected(int id)
        {
            _displayedItems.DetectedSensors.Add(id);
        }

        public void ClearSensorDetected(int id)
        {
            _displayedItems.DetectedSensors.Remove(id);
        }

        public void ShowSensorLowBattery(ICollection<int> ids)
        {
            _displayedItems.LowBatterySensors.Clear();
            _displayedItems.LowBatterySensors.AddRange(ids);
        }

        public void ShowPowerSupplyLowBattery()
        {
            _displayedItems.PowerSupplyLowBattery = true;
        }

        public void ShowAlarmSound()
        {
            _displayedItems.AlarmSound = true;
        }

        public void ClearAlarmSound()
        {
            _displayedItems.AlarmSound = false;
        }

        public void ShowSystemArmed()
        {
            _displayedItems.Armed = true;
            _displayedItems.Stay = false;
        }

        public void ClearSystemArmed()
        {
            _displayedItems.Armed = false;
            _displayedItems.Stay = false;
        }

        public void ShowSystemArmedStay()
        {
            _displayedItems.Armed = true;
            _displayedItems.Stay = true;
        }

        public void ShowSentReport(string reportDetail)
        {
            _displayedItems.ReportDetail = reportDetail;
            SetMessage(reportDetail);
        }

        public void ClearSentReport()
        {
            _displayedItems.ReportDetail = string.Empty;
        }

        private void SetMessage(string message)
        {
            EventHandler<MessageAddedArgs> handler = MessageAdded;
            if (handler != null)
                handler(this, new MessageAddedArgs { Message = message });
        }
    }

    public class MessageAddedArgs : EventArgs
    {
        public string Message { set; get; }
    }
}
