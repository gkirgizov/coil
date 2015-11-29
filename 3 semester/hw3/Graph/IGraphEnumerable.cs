using System.Collections.Generic;

namespace hw3 {
    interface IGraphEnumerable<T> : IEnumerable<T> {
        IGraphEnumerator<T> GetGraphEnumerator();
    }
}
