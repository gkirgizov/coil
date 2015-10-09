using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2 {
    public interface IGraphEnumerator<T> : IEnumerator<T> {
        int CurrentIndex { get; }

        ICollection<T> GetNeighbors();

        ICollection<int> GetNeighborsIndexes();
    }
}
