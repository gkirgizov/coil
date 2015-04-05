using System;
using System.Collections.Generic;

namespace Task6
{
    public class CalculatorCore
    {
        public CalculatorCore()
        {
            ResultsBuffer = new List<double>() {0};
            IsOperatorInputted = false;
            IsDigitsInputted = false;
            IsPointLast = false;
        }

        public List<double> ResultsBuffer { get; set; }

        //public bool IsInputBoxEmpty
        //{
        //    get
        //    {
        //        return !this.IsOperatorInputted && !this.IsDigitsInputted;
        //    }
        //}

        public bool IsPointLast { get; set; }

        public bool IsDigitsInputted { get; set; }

        public bool IsOperatorInputted { get; set; }

        public char LastOperator { get; set; }

        public static double Operation(char key, double first, double second)
        {
            if (key == '+')
            {
                return first + second;
            }
            else if (key == '-')
            {
                return first - second;
            }
            else if (key == '*')
            {
                return first * second;
            }
            else if (key == '/')
            {
                return first / second;
            }
            return default(Double);
        }

        private class Journal : List<double>
        {
            //public override 
        }
    }
}
