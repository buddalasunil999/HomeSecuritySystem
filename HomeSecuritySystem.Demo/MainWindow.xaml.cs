using HomeSecurityControl;
using HomeSecuritySystem.Sensors;
using System.Collections.Generic;
using System.Windows;

namespace HomeSecuritySystemDemo
{
    public partial class MainWindow : Window
    {
        private SmokeSensor _smokeSensor;
        private MotionSensor _motionSensor;
        private PowerSupply _powerSupply;
        private SecurityAlarm _alarm;
        private SecurityController _controller;

        public MainWindow()
        {
            InitializeComponent();

            ICollection<ISensor> sensors = new List<ISensor>();
            _smokeSensor = new SmokeSensor(1);
            _motionSensor = new MotionSensor(2);
            var comms = new CommunicationUnit();
            _powerSupply = new PowerSupply();
            _alarm = new SecurityAlarm();

            sensors.Add(_smokeSensor);
            sensors.Add(_motionSensor);

            rbSmokeSensorOn.IsChecked = true;
            rbMotionSensorOn.IsChecked = true;
            rbAlarmOn.IsChecked = true;

            _controller = new SecurityController(sensors, comms,
            _powerSupply, _alarm, userDisplay);
        }

        private void btnTriggerSmokeSensor_Click(object sender, RoutedEventArgs e)
        {
            _smokeSensor.Trigger();
        }

        private void rbSmokeSensorOn_Checked(object sender, RoutedEventArgs e)
        {
            _smokeSensor.SwitchOn();
        }

        private void rbSmokeSensorOff_Checked(object sender, RoutedEventArgs e)
        {
            _smokeSensor.SwitchOff();
        }

        private void rbMotionSensorOn_Checked(object sender, RoutedEventArgs e)
        {
            _motionSensor.SwitchOn();
        }

        private void rbMotionSensorOff_Checked(object sender, RoutedEventArgs e)
        {
            _motionSensor.SwitchOff();
        }

        private void btnTriggerMotionSensor_Click(object sender, RoutedEventArgs e)
        {
            _motionSensor.Trigger();
        }

        private void ArmOrDisarmController()
        {
            if (cbArm.IsChecked != null && (bool)cbArm.IsChecked)
                _controller.Arm();
            else
                _controller.Disarm();
        }

        private void cbArm_Click(object sender, RoutedEventArgs e)
        {
            ArmOrDisarmController();
        }

        private void cbStay_Click(object sender, RoutedEventArgs e)
        {
            if (cbStay.IsChecked != null && (bool)cbStay.IsChecked)
            {
                cbArm.IsChecked = true;
                _controller.ArmStay();
            }
            else
                ArmOrDisarmController();
        }

        private void cbPowerSupplyOff_Click(object sender, RoutedEventArgs e)
        {
            if (cbPowerSupplyOff.IsChecked != null && (bool)cbPowerSupplyOff.IsChecked)
                _powerSupply.TriggerLowPower();
            else
                _powerSupply.ResetLowPower();
        }

        private void rbAlarmOn_Checked(object sender, RoutedEventArgs e)
        {
            _alarm.SwitchOn();
        }

        private void rbAlarmOff_Checked(object sender, RoutedEventArgs e)
        {
            _alarm.SwitchOff();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            _controller.ClearMemory();
            cbArm.IsChecked = false;
            cbStay.IsChecked = false;
        }
    }
}
