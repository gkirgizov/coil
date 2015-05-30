namespace Task6
{
    partial class Calculator
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.buttonOperationSum = new System.Windows.Forms.Button();
            this.buttonDigit0 = new System.Windows.Forms.Button();
            this.buttonOperationSubtraction = new System.Windows.Forms.Button();
            this.buttonDigit3 = new System.Windows.Forms.Button();
            this.buttonDigit2 = new System.Windows.Forms.Button();
            this.buttonDigit1 = new System.Windows.Forms.Button();
            this.buttonDigit4 = new System.Windows.Forms.Button();
            this.buttonDigit5 = new System.Windows.Forms.Button();
            this.buttonDigit6 = new System.Windows.Forms.Button();
            this.buttonOperationMultiplication = new System.Windows.Forms.Button();
            this.buttonDigit7 = new System.Windows.Forms.Button();
            this.buttonDigit8 = new System.Windows.Forms.Button();
            this.buttonDigit9 = new System.Windows.Forms.Button();
            this.buttonOperationDivision = new System.Windows.Forms.Button();
            this.buttonBackspace = new System.Windows.Forms.Button();
            this.buttonPoint = new System.Windows.Forms.Button();
            this.buttonCancelLast = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.resultsJournal = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputTextBox
            // 
            this.InputTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.SetColumnSpan(this.InputTextBox, 2);
            this.InputTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.InputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputTextBox.Location = new System.Drawing.Point(147, 31);
            this.InputTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.ReadOnly = true;
            this.InputTextBox.Size = new System.Drawing.Size(132, 20);
            this.InputTextBox.TabIndex = 0;
            this.InputTextBox.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.ResultTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.InputTextBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonOperationSum, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.buttonDigit0, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.buttonOperationSubtraction, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonDigit3, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonDigit2, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonDigit1, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonDigit4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonDigit5, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonDigit6, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonOperationMultiplication, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonDigit7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonDigit8, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonDigit9, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonOperationDivision, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonBackspace, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonPoint, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.buttonCancelLast, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonCancel, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonCalculate, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.resultsJournal, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 261);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.SetColumnSpan(this.ResultTextBox, 2);
            this.ResultTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ResultTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultTextBox.Location = new System.Drawing.Point(5, 31);
            this.ResultTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ReadOnly = true;
            this.ResultTextBox.Size = new System.Drawing.Size(132, 20);
            this.ResultTextBox.TabIndex = 22;
            this.ResultTextBox.TabStop = false;
            // 
            // buttonOperationSum
            // 
            this.buttonOperationSum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOperationSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOperationSum.Location = new System.Drawing.Point(218, 225);
            this.buttonOperationSum.Margin = new System.Windows.Forms.Padding(5);
            this.buttonOperationSum.Name = "buttonOperationSum";
            this.buttonOperationSum.Size = new System.Drawing.Size(61, 31);
            this.buttonOperationSum.TabIndex = 12;
            this.buttonOperationSum.Text = "+";
            this.buttonOperationSum.UseVisualStyleBackColor = true;
            this.buttonOperationSum.Click += new System.EventHandler(this.ButtonOperationClick);
            // 
            // buttonDigit0
            // 
            this.buttonDigit0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDigit0.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDigit0.Location = new System.Drawing.Point(5, 225);
            this.buttonDigit0.Margin = new System.Windows.Forms.Padding(5);
            this.buttonDigit0.Name = "buttonDigit0";
            this.buttonDigit0.Size = new System.Drawing.Size(61, 31);
            this.buttonDigit0.TabIndex = 10;
            this.buttonDigit0.Text = "0";
            this.buttonDigit0.UseVisualStyleBackColor = true;
            this.buttonDigit0.Click += new System.EventHandler(this.ButtonDigitClick);
            // 
            // buttonOperationSubtraction
            // 
            this.buttonOperationSubtraction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOperationSubtraction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOperationSubtraction.Location = new System.Drawing.Point(218, 184);
            this.buttonOperationSubtraction.Margin = new System.Windows.Forms.Padding(5);
            this.buttonOperationSubtraction.Name = "buttonOperationSubtraction";
            this.buttonOperationSubtraction.Size = new System.Drawing.Size(61, 31);
            this.buttonOperationSubtraction.TabIndex = 13;
            this.buttonOperationSubtraction.Text = "-";
            this.buttonOperationSubtraction.UseVisualStyleBackColor = true;
            this.buttonOperationSubtraction.Click += new System.EventHandler(this.ButtonOperationClick);
            // 
            // buttonDigit3
            // 
            this.buttonDigit3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDigit3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDigit3.Location = new System.Drawing.Point(147, 184);
            this.buttonDigit3.Margin = new System.Windows.Forms.Padding(5);
            this.buttonDigit3.Name = "buttonDigit3";
            this.buttonDigit3.Size = new System.Drawing.Size(61, 31);
            this.buttonDigit3.TabIndex = 9;
            this.buttonDigit3.Text = "3";
            this.buttonDigit3.UseVisualStyleBackColor = true;
            this.buttonDigit3.Click += new System.EventHandler(this.ButtonDigitClick);
            // 
            // buttonDigit2
            // 
            this.buttonDigit2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDigit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDigit2.Location = new System.Drawing.Point(76, 184);
            this.buttonDigit2.Margin = new System.Windows.Forms.Padding(5);
            this.buttonDigit2.Name = "buttonDigit2";
            this.buttonDigit2.Size = new System.Drawing.Size(61, 31);
            this.buttonDigit2.TabIndex = 8;
            this.buttonDigit2.Text = "2";
            this.buttonDigit2.UseVisualStyleBackColor = true;
            this.buttonDigit2.Click += new System.EventHandler(this.ButtonDigitClick);
            // 
            // buttonDigit1
            // 
            this.buttonDigit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDigit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDigit1.Location = new System.Drawing.Point(5, 184);
            this.buttonDigit1.Margin = new System.Windows.Forms.Padding(5);
            this.buttonDigit1.Name = "buttonDigit1";
            this.buttonDigit1.Size = new System.Drawing.Size(61, 31);
            this.buttonDigit1.TabIndex = 7;
            this.buttonDigit1.Text = "1";
            this.buttonDigit1.UseVisualStyleBackColor = true;
            this.buttonDigit1.Click += new System.EventHandler(this.ButtonDigitClick);
            // 
            // buttonDigit4
            // 
            this.buttonDigit4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDigit4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDigit4.Location = new System.Drawing.Point(5, 143);
            this.buttonDigit4.Margin = new System.Windows.Forms.Padding(5);
            this.buttonDigit4.Name = "buttonDigit4";
            this.buttonDigit4.Size = new System.Drawing.Size(61, 31);
            this.buttonDigit4.TabIndex = 4;
            this.buttonDigit4.Text = "4";
            this.buttonDigit4.UseVisualStyleBackColor = true;
            this.buttonDigit4.Click += new System.EventHandler(this.ButtonDigitClick);
            // 
            // buttonDigit5
            // 
            this.buttonDigit5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDigit5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDigit5.Location = new System.Drawing.Point(76, 143);
            this.buttonDigit5.Margin = new System.Windows.Forms.Padding(5);
            this.buttonDigit5.Name = "buttonDigit5";
            this.buttonDigit5.Size = new System.Drawing.Size(61, 31);
            this.buttonDigit5.TabIndex = 5;
            this.buttonDigit5.Text = "5";
            this.buttonDigit5.UseVisualStyleBackColor = true;
            this.buttonDigit5.Click += new System.EventHandler(this.ButtonDigitClick);
            // 
            // buttonDigit6
            // 
            this.buttonDigit6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDigit6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDigit6.Location = new System.Drawing.Point(147, 143);
            this.buttonDigit6.Margin = new System.Windows.Forms.Padding(5);
            this.buttonDigit6.Name = "buttonDigit6";
            this.buttonDigit6.Size = new System.Drawing.Size(61, 31);
            this.buttonDigit6.TabIndex = 6;
            this.buttonDigit6.Text = "6";
            this.buttonDigit6.UseVisualStyleBackColor = true;
            this.buttonDigit6.Click += new System.EventHandler(this.ButtonDigitClick);
            // 
            // buttonOperationMultiplication
            // 
            this.buttonOperationMultiplication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOperationMultiplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOperationMultiplication.Location = new System.Drawing.Point(218, 143);
            this.buttonOperationMultiplication.Margin = new System.Windows.Forms.Padding(5);
            this.buttonOperationMultiplication.Name = "buttonOperationMultiplication";
            this.buttonOperationMultiplication.Size = new System.Drawing.Size(61, 31);
            this.buttonOperationMultiplication.TabIndex = 14;
            this.buttonOperationMultiplication.Text = "*";
            this.buttonOperationMultiplication.UseVisualStyleBackColor = true;
            this.buttonOperationMultiplication.Click += new System.EventHandler(this.ButtonOperationClick);
            // 
            // buttonDigit7
            // 
            this.buttonDigit7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDigit7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDigit7.Location = new System.Drawing.Point(5, 102);
            this.buttonDigit7.Margin = new System.Windows.Forms.Padding(5);
            this.buttonDigit7.Name = "buttonDigit7";
            this.buttonDigit7.Size = new System.Drawing.Size(61, 31);
            this.buttonDigit7.TabIndex = 1;
            this.buttonDigit7.Text = "7";
            this.buttonDigit7.UseVisualStyleBackColor = true;
            this.buttonDigit7.Click += new System.EventHandler(this.ButtonDigitClick);
            // 
            // buttonDigit8
            // 
            this.buttonDigit8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDigit8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDigit8.Location = new System.Drawing.Point(76, 102);
            this.buttonDigit8.Margin = new System.Windows.Forms.Padding(5);
            this.buttonDigit8.Name = "buttonDigit8";
            this.buttonDigit8.Size = new System.Drawing.Size(61, 31);
            this.buttonDigit8.TabIndex = 2;
            this.buttonDigit8.Text = "8";
            this.buttonDigit8.UseVisualStyleBackColor = true;
            this.buttonDigit8.Click += new System.EventHandler(this.ButtonDigitClick);
            // 
            // buttonDigit9
            // 
            this.buttonDigit9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDigit9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDigit9.Location = new System.Drawing.Point(147, 102);
            this.buttonDigit9.Margin = new System.Windows.Forms.Padding(5);
            this.buttonDigit9.Name = "buttonDigit9";
            this.buttonDigit9.Size = new System.Drawing.Size(61, 31);
            this.buttonDigit9.TabIndex = 3;
            this.buttonDigit9.Text = "9";
            this.buttonDigit9.UseVisualStyleBackColor = true;
            this.buttonDigit9.Click += new System.EventHandler(this.ButtonDigitClick);
            // 
            // buttonOperationDivision
            // 
            this.buttonOperationDivision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOperationDivision.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOperationDivision.Location = new System.Drawing.Point(218, 102);
            this.buttonOperationDivision.Margin = new System.Windows.Forms.Padding(5);
            this.buttonOperationDivision.Name = "buttonOperationDivision";
            this.buttonOperationDivision.Size = new System.Drawing.Size(61, 31);
            this.buttonOperationDivision.TabIndex = 15;
            this.buttonOperationDivision.Text = "/";
            this.buttonOperationDivision.UseVisualStyleBackColor = true;
            this.buttonOperationDivision.Click += new System.EventHandler(this.ButtonOperationClick);
            // 
            // buttonBackspace
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonBackspace, 2);
            this.buttonBackspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBackspace.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBackspace.Location = new System.Drawing.Point(5, 61);
            this.buttonBackspace.Margin = new System.Windows.Forms.Padding(5);
            this.buttonBackspace.Name = "buttonBackspace";
            this.buttonBackspace.Size = new System.Drawing.Size(132, 31);
            this.buttonBackspace.TabIndex = 19;
            this.buttonBackspace.Text = "Backspace";
            this.buttonBackspace.UseVisualStyleBackColor = true;
            this.buttonBackspace.Click += new System.EventHandler(this.ButtonBackspaceClick);
            // 
            // buttonPoint
            // 
            this.buttonPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPoint.Location = new System.Drawing.Point(76, 225);
            this.buttonPoint.Margin = new System.Windows.Forms.Padding(5);
            this.buttonPoint.Name = "buttonPoint";
            this.buttonPoint.Size = new System.Drawing.Size(61, 31);
            this.buttonPoint.TabIndex = 11;
            this.buttonPoint.Text = ".";
            this.buttonPoint.UseVisualStyleBackColor = true;
            this.buttonPoint.Click += new System.EventHandler(this.ButtonPointClick);
            // 
            // buttonCancelLast
            // 
            this.buttonCancelLast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancelLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancelLast.Location = new System.Drawing.Point(147, 61);
            this.buttonCancelLast.Margin = new System.Windows.Forms.Padding(5);
            this.buttonCancelLast.Name = "buttonCancelLast";
            this.buttonCancelLast.Size = new System.Drawing.Size(61, 31);
            this.buttonCancelLast.TabIndex = 20;
            this.buttonCancelLast.Text = "CE";
            this.buttonCancelLast.UseVisualStyleBackColor = true;
            this.buttonCancelLast.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(218, 61);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(61, 31);
            this.buttonCancel.TabIndex = 21;
            this.buttonCancel.Text = "C";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCalculate.Location = new System.Drawing.Point(147, 225);
            this.buttonCalculate.Margin = new System.Windows.Forms.Padding(5);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(61, 31);
            this.buttonCalculate.TabIndex = 18;
            this.buttonCalculate.Text = "=";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.ButtonCalculateClick);
            // 
            // resultsJournal
            // 
            this.resultsJournal.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.SetColumnSpan(this.resultsJournal, 2);
            this.resultsJournal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsJournal.FormattingEnabled = true;
            this.resultsJournal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.resultsJournal.Location = new System.Drawing.Point(74, 3);
            this.resultsJournal.MaxDropDownItems = 10;
            this.resultsJournal.Name = "resultsJournal";
            this.resultsJournal.Size = new System.Drawing.Size(136, 21);
            this.resultsJournal.TabIndex = 23;
            this.resultsJournal.SelectedIndexChanged += new System.EventHandler(this.ResultsJournalSelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 26);
            this.label1.TabIndex = 24;
            this.label1.Text = "Journal:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CalculatorGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(900, 600);
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "CalculatorGUI";
            this.Text = "Calculator";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonDigit1;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Button buttonDigit0;
        private System.Windows.Forms.Button buttonPoint;
        private System.Windows.Forms.Button buttonOperationSubtraction;
        private System.Windows.Forms.Button buttonDigit9;
        private System.Windows.Forms.Button buttonDigit8;
        private System.Windows.Forms.Button buttonDigit7;
        private System.Windows.Forms.Button buttonOperationMultiplication;
        private System.Windows.Forms.Button buttonDigit6;
        private System.Windows.Forms.Button buttonDigit5;
        private System.Windows.Forms.Button buttonDigit4;
        private System.Windows.Forms.Button buttonOperationDivision;
        private System.Windows.Forms.Button buttonDigit3;
        private System.Windows.Forms.Button buttonDigit2;
        private System.Windows.Forms.Button buttonOperationSum;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonCancelLast;
        private System.Windows.Forms.Button buttonBackspace;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.ComboBox resultsJournal;
        private System.Windows.Forms.Label label1;

    }
}

