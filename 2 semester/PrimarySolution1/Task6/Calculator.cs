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

        private void ButtonCancelLastClick(object sender, EventArgs e)
        {
            this.InputTextBox.Clear();
            core.IsPointLast = false;
            core.IsDigitsInputted = false;
            core.IsOperatorInputted = false;
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            this.InputTextBox.Clear();
            core.IsPointLast = false;
            core.IsDigitsInputted = false;
            core.IsOperatorInputted = false;
            core.ActualResultsBufferIndex = 0;
            this.ResultTextBox.Text = "0";
        }
        
        #region Digits' butttons
        private void ButtonDigit7Click(object sender, EventArgs e)
        {
            AddDigit("7");
        }

        private void ButtonDigit8Click(object sender, EventArgs e)
        {
            AddDigit("8");
        }

        private void ButtonDigit9Click(object sender, EventArgs e)
        {
            AddDigit("9");
        }

        private void ButtonDigit4Click(object sender, EventArgs e)
        {
            AddDigit("4");
        }

        private void ButtonDigit5Click(object sender, EventArgs e)
        {
            AddDigit("5");
        }

        private void ButtonDigit6Click(object sender, EventArgs e)
        {
            AddDigit("6");
        }

        private void ButtonDigit1Click(object sender, EventArgs e)
        {
            AddDigit("1");
        }

        private void ButtonDigit2Click(object sender, EventArgs e)
        {
            AddDigit("2");
        }

        private void ButtonDigit3Click(object sender, EventArgs e)
        {
            AddDigit("3");
        }

        private void ButtonDigit0Click(object sender, EventArgs e)
        {
            AddDigit("0");
        }
        #endregion

        private void ButtonPointClick(object sender, EventArgs e)
        {
            if (core.IsDigitsInputted && !core.IsPointLast) 
            {
                this.InputTextBox.AppendText(",");
                core.IsPointLast = true;
            }
        }

        #region Operations buttons
        private void ButtonOperationDivisionClick(object sender, EventArgs e)
        {
            TextBoxHandler('/');
        }

        private void ButtonOperationMultiplicationClick(object sender, EventArgs e)
        {
            TextBoxHandler('*');
        }

        private void ButtonOperationSubtractionClick(object sender, EventArgs e)
        {
            TextBoxHandler('-');
        }

        private void ButtonOperationSumClick(object sender, EventArgs e)
        {
            TextBoxHandler('+');
        }
        #endregion

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
