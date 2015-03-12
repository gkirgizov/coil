using System;

namespace Task4
{
    public class UnexpectedInputData : ApplicationException
    {
        public UnexpectedInputData() { }

        public UnexpectedInputData(string message)
            : base(message) { }
    }
}
