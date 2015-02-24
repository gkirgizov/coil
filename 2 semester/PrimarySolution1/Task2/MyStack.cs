using System;

namespace Task2
{
    //Interface for stack
    interface MyStack<T>
    {
        //Return number of items in stack
        uint Size
        {
            get;
        }

        //Add item to stack
        void Push(T newData);

        //Delete top item and return it
        T Pop();

        //Return top item
        T Top();
    }
}
