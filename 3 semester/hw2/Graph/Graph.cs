using System;
using System.Collections;
using System.Collections.Generic;

namespace hw2 {
    public class Graph<T> : IGraphEnumerable<T> {

        public Graph(int size = 1) {
            this.items = new List<T>(size);
            this.links = new List<List<int>>(size);
            for (int i = 0; i < size; ++i) {
                this.links.Add(new List<int>());
            }
        }
        public Graph(ICollection<T> items) : this(items.Count) {
            this.items = new List<T>(items);
        }
        public Graph(ICollection<T> items, List<List<int>> links) : this(items) {
            int size = Count < links.Count ? Count : links.Count;
            for (int i = 0; i < size; ++i) {
                foreach (var link in links[i]) {
                    this.links[i].Add(link);
                }
            }
        }

        public void AddItem(T item) {
            this.links.Add(new List<int>());
            this.items.Add(item);
        }

        public void AddEdge(int from, int to) {
            if (from != to) {
                if (!this.links[from].Contains(to)) {
                    this.links[from].Add(to);
                }
                if (!this.links[to].Contains(from)) {
                    this.links[to].Add(from);
                }
            }
        }

        private void Remove(int itemIndex) {
            foreach (var linkList in this.links) {
                linkList.Remove(itemIndex);
            }
            this.links.RemoveAt(itemIndex);
            this.items.RemoveAt(itemIndex);
        }

        public IGraphEnumerator<T> GetGraphEnumerator() {
            return new GraphEnumerator<T>(items, links);
        }
        public IEnumerator<T> GetEnumerator() {
            return new GraphEnumerator<T>(items, links);
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return GetGraphEnumerator();
        }

        public int Count {
            get { return this.items.Count; }
        }

        private List<T> items;
        /// <summary>
        /// Adjacency list.
        /// </summary>
        private List<List<int>> links;
    }
}
