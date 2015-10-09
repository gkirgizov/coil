using System.Collections.Generic;

namespace hw2 {
    interface IGraphEnumerable<T> : IEnumerable<T> {
        IGraphEnumerator<T> GetGraphEnumerator();
    }
}
