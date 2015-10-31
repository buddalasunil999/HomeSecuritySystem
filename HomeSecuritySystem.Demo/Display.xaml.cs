using HomeSecuritySystem;
using HomeSecuritySystem.Display;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace HomeSecuritySystemDemo
{
    public partial class Display : UserControl, IDisplay
    {
        public Display()
        {
            InitializeComponent();

            _details = new DisplayDetails();
            _details.DetectedSensors = new List<int>();
            _details.LowBatterySensors = new List<int>();
            _details.PowerSupplyLowBattery = false;
            _details.AlarmSound = false;
            _details.Armed = false;
            _details.Stay = false;
            _details.SystemReady = false;
            grid.DataContext = _details;
        }

        private DisplayedItems _displayedItems;
        private DisplayDetails _details;

        public DisplayedItems DisplayedItems
        {
            get { return _displayedItems; }
        }

        public void ShowSystemReady()
        {
            _details.SystemReady = true;
        }

        public void ShowSystemNotReady()
        {
            _details.SystemReady = false;
        }

        public void ShowSensorDetected(int id)
        {
            _details.DetectedSensors.Add(id);
        }

        public void ClearSensorDetected(int id)
        {
            _details.DetectedSensors.Remove(id);
        }

        public void ShowSensorLowBattery(ICollection<int> ids)
        {
            _details.LowBatterySensors.Clear();
            _details.LowBatterySensors.AddRange(ids);
        }

        public void ShowPowerSupplyLowBattery()
        {
            _details.PowerSupplyLowBattery = true;
        }

        public void ShowAlarmSound()
        {
            _details.AlarmSound = true;
        }

        public void ClearAlarmSound()
        {
            _details.AlarmSound = false;
        }

        public void ShowSystemArmed()
        {
            _details.Armed = true;
            _details.Stay = false;
        }

        public void ClearSystemArmed()
        {
            _details.Armed = false;
            _details.Stay = false;
        }

        public void ShowSystemArmedStay()
        {
            _details.Armed = true;
            _details.Stay = true;
        }

        public void ShowSentReport(string reportDetail)
        {
            _details.ReportDetail = reportDetail;
        }

        public void ClearSentReport()
        {
            _details.ReportDetail = string.Empty;
        }
    }

    public class DisplayDetails : INotifyPropertyChanged
    {
        private bool _alarmSound;
        private bool _armed;
        private List<int> _detectedSensors;
        private List<int> _lowBatterySensors;
        private bool _powerSupplyLowBattery;
        private string _reportDetail;
        private bool _stay;
        private bool _systemReady;

        public bool AlarmSound
        {
            set
            {
                _alarmSound = value;
                OnPropertyChanged(new PropertyChangedEventArgs("AlarmSound"));
            }
            get { return _alarmSound; }
        }

        public bool Armed
        {
            set
            {
                _armed = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Armed"));
            }
            get { return _armed; }
        }

        public List<int> DetectedSensors
        {
            set
            {
                _detectedSensors = value;
                OnPropertyChanged(new PropertyChangedEventArgs("DetectedSensors"));
            }
            get { return _detectedSensors; }
        }

        public List<int> LowBatterySensors
        {
            set
            {
                _lowBatterySensors = value;
                OnPropertyChanged(new PropertyChangedEventArgs("LowBatterySensors"));
            }
            get { return _lowBatterySensors; }
        }

        public bool PowerSupplyLowBattery
        {
            set
            {
                _powerSupplyLowBattery = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PowerSupplyLowBattery"));
            }
            get { return _powerSupplyLowBattery; }
        }

        public string ReportDetail
        {
            set
            {
                _reportDetail = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ReportDetail"));
            }
            get { return _reportDetail; }
        }

        public bool Stay
        {
            set
            {
                _stay = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Stay"));
            }
            get { return _stay; }
        }

        public bool SystemReady
        {
            set
            {
                _systemReady = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SystemReady"));
            }
            get { return _systemReady; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }

    [ValueConversion(typeof(List<int>), typeof(object))]
    public class ListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(object))
                throw new InvalidOperationException("The target must be a String");

            return String.Join(", ", ((List<int>)value).ToArray());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
