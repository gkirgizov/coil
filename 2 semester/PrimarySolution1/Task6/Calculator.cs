using System;
using System.Windows.Forms;

namespace Task6
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
            this.ResultTextBox.Text = "0";
        }

        private static CalculatorCore core = new CalculatorCore();

        private void ButtonBackspaceClick(object sender, EventArgs e)
        {
            if (this.InputTextBox.Text.Length > 0)
            {
                int last = this.InputTextBox.Text.Length - 1;

                if (this.InputTextBox.Text[last] != ' ')
                {
                    if (this.InputTextBox.Text[last] == ',')
                    {
                        core.IsPointLast = false;
                    }
                    this.InputTextBox.Text = this.InputTextBox.Text.Remove(last);
                    --last;
                }

                if (last < 0)
                {
                    core.IsDigitsInputted = false;
                }
                else
                {
                    if (core.IsOperatorInputted)
                    {
                        if (last < 2)
                        {
                            core.IsDigitsInputted = false;
                        }
                    }
                    else
                    {
                        if (this.InputTextBox.Text[last] == ',')
                        {
                            core.IsPointLast = true;
                        }
                    }
                }
            }
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            this.InputTextBox.Clear();
            core.IsPointLast = false;
            core.IsDigitsInputted = false;
            core.IsOperatorInputted = false;
            if ((Button)sender == this.buttonCancel)
            {
                core.ActualResultsBufferIndex = 0;
                this.ResultTextBox.Text = "0";
            }
        }

        private void ButtonDigitClick(object sender, EventArgs e)
        {
            Button digit = sender as Button;
            AddDigit(digit.Text);
        }

        private void ButtonPointClick(object sender, EventArgs e)
        {
            if (core.IsDigitsInputted && !core.IsPointLast)
            {
                this.InputTextBox.AppendText(",");
                core.IsPointLast = true;
            }
        }

        private void ButtonOperationClick(object sender, EventArgs e)
        {
            Button operation = sender as Button;
            TextBoxHandler(operation.Text[0]);
        }

        private void ButtonCalculateClick(object sender, EventArgs e)
        {
            if (core.IsOperatorInputted && core.IsDigitsInputted)
            {
                var result = DoOperation(core.LastOperator);
                core.IsOperatorInputted = false;

                AddToJournal(result, false);
                FormatAndWriteToResultBox(result);

                this.InputTextBox.Clear();
                core.IsDigitsInputted = false;
            }
        }

        private void ResultsJournalSelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeActualValue();
        }


        /// <summary>
        /// Handle with text boxes
        /// </summary>
        private void TextBoxHandler(char key)
        {
            if (!core.IsPointLast)
            {
                if (core.IsDigitsInputted)
                {
                    if (!core.IsOperatorInputted)
                    {
                        this.ResultTextBox.Text = this.InputTextBox.Text;
                        var inputted = Double.Parse(this.ResultTextBox.Text);
                        AddToJournal(inputted, true);
                    }
                    else
                    {
                        var result = DoOperation(core.LastOperator);
                        core.IsOperatorInputted = false;

                        AddToJournal(result, false);
                        FormatAndWriteToResultBox(result);
                    }
                    this.InputTextBox.Clear();
                    core.IsDigitsInputted = false;
                }
                if (!core.IsOperatorInputted)
                {
                    AddOperator(key);
                }
            }
        }

        /// <summary>
        /// Calculates equation inputted in text boxes
        /// </summary>
        private double DoOperation(char key)
        {
            double first = core.ResultsBuffer[core.ActualResultsBufferIndex];
            if (core.IsOperatorInputted)
            {
                this.InputTextBox.Text = this.InputTextBox.Text.Substring(2);
            }
            double second = Double.Parse(this.InputTextBox.Text);
            return CalculatorCore.Operation(key, first, second);
        }

        /// <summary>
        /// Handle operator input
        /// </summary>
        private void AddOperator(char key)
        {
            core.LastOperator = key;
            this.InputTextBox.AppendText(String.Concat(key, ' '));
            core.IsOperatorInputted = true;
        }

        /// <summary>
        /// Handle digits input
        /// </summary>
        private void AddDigit(string digit)
        {
            this.InputTextBox.AppendText(digit);
            core.IsDigitsInputted = true;
            core.IsPointLast = false;
        }

        /// <summary>
        /// Operate with result journal
        /// </summary>
        private void AddToJournal(double data, bool IsOnlyDigit)
        {
            string buffer;
            if (IsOnlyDigit)
            {
                buffer = this.ResultTextBox.Text;
            }
            else
            {
                buffer = String.Concat(this.ResultTextBox.Text, " ", core.LastOperator, " ", this.InputTextBox.Text);
            }
            this.resultsJournal.Items.Add(buffer);
            core.ResultsBuffer.Add(data);
            ++core.ActualResultsBufferIndex;

            if (this.resultsJournal.Items.Count > 4)
            {
                this.resultsJournal.Items.RemoveAt(0);
                core.ResultsBuffer.RemoveAt(1);
            }
            resultsJournal.SelectedIndex = this.resultsJournal.Items.Count - 1;
        }

        /// <summary>
        /// Changes actual value according to the selected value in journal
        /// </summary>
        private void ChangeActualValue()
        {
            core.ActualResultsBufferIndex = resultsJournal.SelectedIndex + 1;
            var result = core.ResultsBuffer[core.ActualResultsBufferIndex];
            FormatAndWriteToResultBox(result);
        }

        private void FormatAndWriteToResultBox(double data)
        {
            string formatted = String.Format("{0:F2}", data);
            this.ResultTextBox.Text = formatted;
        }
    }
}
