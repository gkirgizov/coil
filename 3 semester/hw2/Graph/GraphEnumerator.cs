using System;
using System.Collections;
using System.Collections.Generic;

namespace hw2 {
    public class GraphEnumerator<T> : IGraphEnumerator<T> {
        public GraphEnumerator(List<T> items, List<List<int>> links) {
            this.items = items;
            this.links = links;
            if (items.Count > 0) {
                current = 0;
                first = current;
            }
        }

        public int CurrentIndex {
            get {
                return current;
            }
        }

        public T Current {
            get {
                return this.items[current];
            }
        }

        object IEnumerator.Current {
            get {
                return Current;
            }
        }

        void IDisposable.Dispose() {}

        public ICollection<T> GetNeighbors() {
            var neighbors = new List<T>(this.items.Count);
            foreach (int neighborIndex in this.links[current]) {
                neighbors.Add(this.items[neighborIndex]);
            }
            return neighbors;
        }

        public ICollection<int> GetNeighborsIndexes() {
            return this.links[current];
        }

        public bool MoveNext() {
            ++current;
            return current < items.Count;
        }

        public void Reset() {
            current = first;
        }

        private int first;
        private int current;
        private List<T> items;
        private List<List<int>> links;
    }
}
