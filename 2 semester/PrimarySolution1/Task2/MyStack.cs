using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    interface MyStack<T>
    {
        uint Size
        {
            get;
        }

        void Push(T newData);

        T Pop();

        T Top();
    }
}
