using System;
using System.Collections;
using System.Collections.Generic;

namespace hw3 {
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

        /// <summary>
        /// Add new item to the graph.
        /// No links will be created.
        /// </summary>
        /// <param name="item">New item.</param>
        public void AddItem(T item) {
            this.links.Add(new List<int>());
            this.items.Add(item);
        }

        /// <summary>
        /// Add undirected edge between nodes.
        /// </summary>
        /// <param name="from">Node from.</param>
        /// <param name="to">Node to.</param>
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

        /// <summary>
        /// Remove item and all the related links.
        /// </summary>
        /// <param name="itemIndex"></param>
        private void Remove(int itemIndex) {
            foreach (var linkList in this.links) {
                linkList.Remove(itemIndex);
            }
            this.links.RemoveAt(itemIndex);
            this.items.RemoveAt(itemIndex);
        }

        /// <summary>
        /// Returns bool graph.
        /// Different values of bool determine different partitions of the graph.
        /// </summary>
        /// <returns>Biparted graph.</returns>
        public Graph<bool> GetBipartition() {
            Func<int, List<bool>> getFalseList = (int size) => {
                var l = new List<bool>(size);
                for (var j = 0; j < size; ++j) {
                    l.Add(false);
                }
                return l;
            };

            var bipartition = getFalseList(items.Count);
            var visited = getFalseList(items.Count);
            var q = new Queue<int>();

            int i = 0;
            visited[i] = true;
            bipartition[i] = false;
            q.Enqueue(i);
            
            while (q.Count != 0) {
                var next = q.Dequeue();
                foreach (var neighbor in links[next]) {
                    if (!visited[neighbor]) {
                        visited[neighbor] = true;
                        q.Enqueue(neighbor);

                        bipartition[neighbor] = !bipartition[next];
                    } else if (bipartition[neighbor] == bipartition[next]) {
                        return new Graph<bool>(getFalseList(items.Count), links);
                    }
                }
            }
            return new Graph<bool>(bipartition, links);
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
