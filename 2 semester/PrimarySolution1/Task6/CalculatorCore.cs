using System;
using System.Collections.Generic;

namespace Task6
{
    public class CalculatorCore
    {
        public CalculatorCore()
        {
            ResultsBuffer = new List<double> { 0 };
            IsOperatorInputted = false;
            IsDigitsInputted = false;
            IsPointLast = false;
            ActualResultsBufferIndex = 0;
        }

        /// <summary>
        /// Contains calculated results
        /// </summary>
        public List<double> ResultsBuffer { get; set; }

        /// <summary>
        /// True - if ',' is last symbol in the input
        /// </summary>
        public bool IsPointLast { get; set; }

        /// <summary>
        /// True - if at least one digit was inputted
        /// </summary>
        public bool IsDigitsInputted { get; set; }

        /// <summary>
        /// True - if any operator was inputted
        /// </summary>
        public bool IsOperatorInputted { get; set; }

        /// <summary>
        /// Contains last inputted operator
        /// </summary>
        public char LastOperator { get; set; }

        /// <summary>
        /// Contains actual index pointing to the actual(selected) data in ResultsBuffer
        /// </summary>
        public int ActualResultsBufferIndex { get; set; }

        /// <summary>
        /// Do operation "key" with operands "first" and "second"
        /// </summary>
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
    }
}
