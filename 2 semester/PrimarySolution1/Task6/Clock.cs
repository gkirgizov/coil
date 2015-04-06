using System;
using System.Windows.Forms;

namespace Task6
{
    public partial class Clock : Form
    {
        public Clock()
        {
            InitializeComponent();
            UpdateTime(DateTime.Now);
        }

        private int hours;

        private int Hours
        {
            get { return hours; }
            set { hours = value % 24; }
        }
        private int Minutes { get; set; }
        private int Seconds { get; set; }

        private DateTime clockCore;

        private void TimerTick(object sender, EventArgs e)
        {
            if (Seconds >= 59)
            {
                Seconds = 0;
                if (Minutes >= 59)
                {
                    Minutes = 0;
                    ++Hours;
                    this.hoursBox.Text = Hours.ToString();
                }
                else
                {
                    ++Minutes;
                }
                this.minutesBox.Text = String.Format("{0:d2}", Minutes);
            }
            else
            {
                ++this.Seconds;
            }
            this.secondsBox.Text = String.Format("{0:d2}", Seconds);
        }

        private void RadioButtonUtcCheckedChanged(object sender, EventArgs e)
        {
            UpdateTime(DateTime.UtcNow);
        }

        private void RadioButtonLocalCheckedChanged(object sender, EventArgs e)
        {
            UpdateTime(DateTime.Now);
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
