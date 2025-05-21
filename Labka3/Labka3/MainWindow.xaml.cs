using System;
using System.Windows;
using System.Windows.Threading;

namespace Labka3
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer _clockTimer;
        private DateTime _alarmTime;
        private bool _alarmSet;

        public MainWindow()
        {
            InitializeComponent();
            InitializeClock();
        }

        private void InitializeClock()
        {
            _clockTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _clockTimer.Tick += UpdateClock;
            _clockTimer.Start();
        }

        private void UpdateClock(object sender, EventArgs e)
        {
            var currentTime = DateTime.Now;

            HourLabel.Text = currentTime.ToString("HH");
            MinuteLabel.Text = currentTime.ToString("mm");
            SecondLabel.Text = currentTime.ToString("ss");
            DayLabel.Text = currentTime.ToString("ddd").ToUpper();
            DateLabel.Text = currentTime.ToString("dd/MM/yyyy");

            if (_alarmSet && currentTime.Hour == _alarmTime.Hour &&
                currentTime.Minute == _alarmTime.Minute &&
                currentTime.Second == _alarmTime.Second)
            {
                TriggerAlarm();
            }
        }

        private void SetAlarm_Click(object sender, RoutedEventArgs e)
        {
            var alarmWindow = new AlarmWindow();
            if (alarmWindow.ShowDialog() == true)
            {
                _alarmTime = alarmWindow.SelectedTime;
                _alarmSet = true;
                MessageBox.Show($"Alarm set for {_alarmTime:HH:mm:ss}\nDescription: {AlarmDescription.Text}");
            }
        }

        private void TriggerAlarm()
        {
            _alarmSet = false;
            MessageBox.Show($"ALARM!\n{AlarmDescription.Text}", "Alarm", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}