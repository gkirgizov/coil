using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task6
{
    public partial class Calculator : Form
    {
        private static CalculatorCore core = new CalculatorCore();

        public Calculator()
        {
            InitializeComponent();
            this.ResultTextBox.Text = "0";
        }

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

                string formattedResult = String.Format("{0:F2}", result);
                this.ResultTextBox.Text = formattedResult;

                this.InputTextBox.Clear();
                core.IsDigitsInputted = false;
            }
        }

        private void TextBoxHandler(char key)
        {
            if (!core.IsPointLast)
            {
                if (core.IsDigitsInputted)
                {
                    if (!core.IsOperatorInputted)
                    {
                        this.ResultTextBox.Text = this.InputTextBox.Text;
                    }
                    else
                    {
                        var result = DoOperation(core.LastOperator);
                        core.IsOperatorInputted = false;

                        string formattedResult = String.Format("{0:F2}", result);
                        this.ResultTextBox.Text = formattedResult;
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

        private double DoOperation(char key)
        {
            //double first = core.ResultsBuffer.ElementAt(core.ResultsBuffer.Count - 1);
            double first = Double.Parse(this.ResultTextBox.Text);
            if (core.IsOperatorInputted)
            {
                this.InputTextBox.Text = this.InputTextBox.Text.Substring(2); 
            }
            double second = Double.Parse(this.InputTextBox.Text);
            return CalculatorCore.Operation(key, first, second);
        }

        private void AddOperator(char key)
        {
            core.LastOperator = key;
            this.InputTextBox.AppendText(String.Concat(key, ' '));
            core.IsOperatorInputted = true;
        }

        private void AddDigit(string digit)
        {
            this.InputTextBox.AppendText(digit);
            core.IsDigitsInputted = true;
            core.IsPointLast = false;
        }
    }
}
