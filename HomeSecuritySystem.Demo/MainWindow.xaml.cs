using HomeSecurityControl;
using HomeSecuritySystem;
using HomeSecuritySystem.Sensors;
using System.Collections.Generic;
using System.Windows;
using System.Threading.Tasks;
using System.Threading;

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
        SystemDisplay display;
        SecurityController controller;
        Stack<string> messages = new Stack<string>();
        TaskScheduler scheduler;

        public MainWindow()
        {
            InitializeComponent();

            rbSmokeSensorOn.IsChecked = true;
            rbMotionSensorOn.IsChecked = true;
            rbPowerSupplyOn.IsChecked = true;

            listBox.ItemsSource = messages;
            scheduler = TaskScheduler.FromCurrentSynchronizationContext();

            display = new SystemDisplay();
            display.MessageAdded += Display_MessageAdded;

            sensors.Add(smokeSensor);
            sensors.Add(motionSensor);

            controller = new SecurityController(sensors, comms,
            powerSupply, alarm, display);
            controller.EnablePeriodicCheck();
        }

        private void Display_MessageAdded(object sender, MessageAddedArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                messages.Push(e.Message);
                listBox.Items.Refresh();
            }, CancellationToken.None, TaskCreationOptions.None, scheduler);
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

        private void rbPowerSupplyOn_Checked(object sender, RoutedEventArgs e)
        {
            powerSupply.SwitchOn();
        }

        private void rbPowerSupplyOff_Checked(object sender, RoutedEventArgs e)
        {
            powerSupply.SwitchOff();
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
    }
}
