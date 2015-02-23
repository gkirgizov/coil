using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    interface MyList<T>
    {
        uint Size
        {
            get;
        }

        void Add(T newData, int index = -1);

        T Get(uint index);

        bool Search(T searchedData);

        void Delete(T deletedData);
    }
}
