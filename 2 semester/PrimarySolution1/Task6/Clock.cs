using System;
using System.Windows.Forms;

namespace Task6
{
    public partial class Clock : Form
    {
        public Clock()
        {
            InitializeComponent();
            isUtc = false;
            UpdateTime(DateTime.Now);
        }

        private int Hours { get; set; }
        private int Minutes { get; set; }
        private int Seconds { get; set; }

        private bool isUtc;

        private DateTime clockCore;

        private void TimerTick(object sender, EventArgs e)
        {
            if (isUtc)
            {
                UpdateTime(DateTime.UtcNow);
            }
            else
            {
                UpdateTime(DateTime.Now);
            }
        }

        private void RadioButtonUtcCheckedChanged(object sender, EventArgs e)
        {
            this.isUtc = true;
        }

        private void RadioButtonLocalCheckedChanged(object sender, EventArgs e)
        {
            this.isUtc = false;
        }

        private void UpdateTime(DateTime datetime)
        {
            clockCore = datetime;
            this.Hours = clockCore.Hour;
            this.Minutes = clockCore.Minute;
            this.Seconds = clockCore.Second;
            this.hoursBox.Text = this.Hours.ToString();
            this.minutesBox.Text = String.Format("{0:d2}", clockCore.Minute);
            this.secondsBox.Text = String.Format("{0:d2}", clockCore.Second);
        }
    }
}
