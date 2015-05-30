namespace Task6
{
    partial class Clock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.minutesBox = new System.Windows.Forms.TextBox();
            this.hoursBox = new System.Windows.Forms.TextBox();
            this.secondsBox = new System.Windows.Forms.TextBox();
            this.radioButtonUtc = new System.Windows.Forms.RadioButton();
            this.radioButtonLocal = new System.Windows.Forms.RadioButton();
            this.clockTabs = new System.Windows.Forms.TabControl();
            this.tabPageDigitalClock = new System.Windows.Forms.TabPage();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.clockTabs.SuspendLayout();
            this.tabPageDigitalClock.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.minutesBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.hoursBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.secondsBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonUtc, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonLocal, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(270, 109);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.TabStop = true;
            // 
            // minutesBox
            // 
            this.minutesBox.BackColor = System.Drawing.SystemColors.Control;
            this.minutesBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minutesBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minutesBox.Location = new System.Drawing.Point(92, 3);
            this.minutesBox.Name = "minutesBox";
            this.minutesBox.Size = new System.Drawing.Size(84, 80);
            this.minutesBox.TabIndex = 1;
            this.minutesBox.TabStop = false;
            this.minutesBox.Text = "mm";
            this.minutesBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hoursBox
            // 
            this.hoursBox.BackColor = System.Drawing.SystemColors.Control;
            this.hoursBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hoursBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hoursBox.Location = new System.Drawing.Point(3, 3);
            this.hoursBox.Name = "hoursBox";
            this.hoursBox.Size = new System.Drawing.Size(83, 80);
            this.hoursBox.TabIndex = 0;
            this.hoursBox.TabStop = false;
            this.hoursBox.Text = "hh";
            this.hoursBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // secondsBox
            // 
            this.secondsBox.BackColor = System.Drawing.SystemColors.Control;
            this.secondsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondsBox.Location = new System.Drawing.Point(182, 3);
            this.secondsBox.Name = "secondsBox";
            this.secondsBox.Size = new System.Drawing.Size(83, 80);
            this.secondsBox.TabIndex = 2;
            this.secondsBox.TabStop = false;
            this.secondsBox.Text = "ss";
            this.secondsBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radioButtonUtc
            // 
            this.radioButtonUtc.AutoSize = true;
            this.radioButtonUtc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonUtc.Location = new System.Drawing.Point(92, 86);
            this.radioButtonUtc.Name = "radioButtonUtc";
            this.radioButtonUtc.Size = new System.Drawing.Size(84, 20);
            this.radioButtonUtc.TabIndex = 5;
            this.radioButtonUtc.TabStop = true;
            this.radioButtonUtc.Text = "Utc";
            this.radioButtonUtc.UseVisualStyleBackColor = true;
            this.radioButtonUtc.CheckedChanged += new System.EventHandler(this.RadioButtonUtcCheckedChanged);
            // 
            // radioButtonLocal
            // 
            this.radioButtonLocal.AutoSize = true;
            this.radioButtonLocal.Checked = true;
            this.radioButtonLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonLocal.Location = new System.Drawing.Point(3, 86);
            this.radioButtonLocal.Name = "radioButtonLocal";
            this.radioButtonLocal.Size = new System.Drawing.Size(83, 20);
            this.radioButtonLocal.TabIndex = 4;
            this.radioButtonLocal.TabStop = true;
            this.radioButtonLocal.Text = "Local";
            this.radioButtonLocal.UseVisualStyleBackColor = true;
            this.radioButtonLocal.CheckedChanged += new System.EventHandler(this.RadioButtonLocalCheckedChanged);
            // 
            // clockTabs
            // 
            this.clockTabs.Controls.Add(this.tabPageDigitalClock);
            this.clockTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clockTabs.Location = new System.Drawing.Point(0, 0);
            this.clockTabs.Name = "clockTabs";
            this.clockTabs.SelectedIndex = 0;
            this.clockTabs.Size = new System.Drawing.Size(284, 141);
            this.clockTabs.TabIndex = 1;
            // 
            // tabPageDigitalClock
            // 
            this.tabPageDigitalClock.Controls.Add(this.tableLayoutPanel1);
            this.tabPageDigitalClock.Location = new System.Drawing.Point(4, 22);
            this.tabPageDigitalClock.Name = "tabPageDigitalClock";
            this.tabPageDigitalClock.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDigitalClock.Size = new System.Drawing.Size(276, 115);
            this.tabPageDigitalClock.TabIndex = 0;
            this.tabPageDigitalClock.Text = "Digital";
            this.tabPageDigitalClock.UseVisualStyleBackColor = true;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.TimerTick);
            // 
            // Clock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 141);
            this.Controls.Add(this.clockTabs);
            this.MaximumSize = new System.Drawing.Size(300, 180);
            this.MinimumSize = new System.Drawing.Size(300, 180);
            this.Name = "Clock";
            this.Text = "Clock";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.clockTabs.ResumeLayout(false);
            this.tabPageDigitalClock.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox hoursBox;
        private System.Windows.Forms.TabControl clockTabs;
        private System.Windows.Forms.TabPage tabPageDigitalClock;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox secondsBox;
        private System.Windows.Forms.RadioButton radioButtonUtc;
        private System.Windows.Forms.TextBox minutesBox;
        private System.Windows.Forms.RadioButton radioButtonLocal;

    }
}