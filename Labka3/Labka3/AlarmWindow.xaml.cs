using System;
using System.Windows;

namespace Labka3
{
    public partial class AlarmWindow : Window
    {
        public DateTime SelectedTime { get; private set; }

        public AlarmWindow()
        {
            InitializeComponent();
            InitializeTimeSelectors();
        }

        private void InitializeTimeSelectors()
        {
            for (int i = 0; i < 24; i++)
            {
                HoursComboBox.Items.Add(i.ToString("00"));
            }
            HoursComboBox.SelectedIndex = DateTime.Now.Hour;

            for (int i = 0; i < 60; i++)
            {
                MinutesComboBox.Items.Add(i.ToString("00"));
                SecondsComboBox.Items.Add(i.ToString("00"));
            }
            MinutesComboBox.SelectedIndex = DateTime.Now.Minute;
            SecondsComboBox.SelectedIndex = 0;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            var time = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                int.Parse(HoursComboBox.SelectedItem.ToString()),
                int.Parse(MinutesComboBox.SelectedItem.ToString()),
                int.Parse(SecondsComboBox.SelectedItem.ToString()));

            SelectedTime = time;
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}