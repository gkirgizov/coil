using System;

namespace Task2
{
    //Interface for list
    interface MyList<T>
    {
        //Return number of items in list
        uint Size
        {
            get;
        }

        //Add new element in list to spot with index.
        //If index = 0 add to head. If index < 0 add to tail.
        void Add(T newData, int index = -1);

        //Return item by index, returns default value if index is out of range
        T Get(uint index);

        //Return true if item is in the list
        bool Search(T searchedData);

        //Delete item by value
        void Delete(T deletedData);
    }
}
