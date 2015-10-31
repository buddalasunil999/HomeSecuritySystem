using HomeSecurityControl;
using HomeSecuritySystem.Sensors;
using System.Collections.Generic;
using System.Windows;

namespace HomeSecuritySystemDemo
{
    public partial class MainWindow : Window
    {
        ICollection<ISensor> sensors = new List<ISensor>();
        SmokeSensor smokeSensor = new SmokeSensor(1);
        MotionSensor motionSensor = new MotionSensor(2);
        CommunicationUnit comms = new CommunicationUnit();
        PowerSupply powerSupply = new PowerSupply();
        SecurityAlarm alarm = new SecurityAlarm();
        SecurityController controller;

        public MainWindow()
        {
            InitializeComponent();

            rbSmokeSensorOn.IsChecked = true;
            rbMotionSensorOn.IsChecked = true;

            sensors.Add(smokeSensor);
            sensors.Add(motionSensor);

            controller = new SecurityController(sensors, comms,
            powerSupply, alarm, userDisplay);
        }

        private void btnTriggerSmokeSensor_Click(object sender, RoutedEventArgs e)
        {
            smokeSensor.Trigger();
        }

        private void rbSmokeSensorOn_Checked(object sender, RoutedEventArgs e)
        {
            smokeSensor.SwitchOn();
        }

        private void rbSmokeSensorOff_Checked(object sender, RoutedEventArgs e)
        {
            smokeSensor.SwitchOff();
        }

        private void rbMotionSensorOn_Checked(object sender, RoutedEventArgs e)
        {
            motionSensor.SwitchOn();
        }

        private void rbMotionSensorOff_Checked(object sender, RoutedEventArgs e)
        {
            motionSensor.SwitchOff();
        }

        private void btnTriggerMotionSensor_Click(object sender, RoutedEventArgs e)
        {
            motionSensor.Trigger();
        }

        private void cbArm_Checked(object sender, RoutedEventArgs e)
        {
            ArmOrDisarmController();
        }

        private void ArmOrDisarmController()
        {
            if ((bool)cbArm.IsChecked)
                controller.Arm();
            else
                controller.Disarm();
        }

        private void cbArm_Click(object sender, RoutedEventArgs e)
        {
            ArmOrDisarmController();
        }

        private void cbStay_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)cbStay.IsChecked)
            {
                cbArm.IsChecked = true;
                controller.ArmStay();
            }
            else
                ArmOrDisarmController();
        }

        private void cbPowerSupplyOff_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)cbPowerSupplyOff.IsChecked)
                powerSupply.TriggerLowPower();
            else
                powerSupply.ResetLowPower();
        }
    }
}
