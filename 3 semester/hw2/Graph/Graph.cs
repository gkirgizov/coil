using System.Collections.Generic;

namespace hw2 {
    class Graph<T> {

        public Graph(int size = 1) {
            Items = new List<T>(size);
            Links = new List<List<int>>(size);
            for (int i = 0; i < size; ++i) {
                Links.Add(new List<int>());
            }
        }

        public Graph(ICollection<T> items) : this(items.Count) {
            this.Items = new List<T>(items);
        }

        public Graph(ICollection<T> items, List<List<int>> links) : this(items) {
            int size = Count < links.Count ? Count : links.Count;
            for (int i = 0; i < size; ++i) {
                foreach (var link in links[i]) {
                    Links[i].Add(link);
                }
            }
        }

        public void AddItem(T item) {
            Links.Add(new List<int>());
            this.Items.Add(item);
        }

        public void AddEdge(int from, int to) {
            if (from != to) {
                if (!Links[from].Contains(to)) {
                    Links[from].Add(to);
                }
                if (!Links[to].Contains(from)) {
                    Links[to].Add(from);
                }
            }
        }

        public List<T> GetNeighbors(int itemIndex) {
            var neighbors = new List<T>(Items.Count);
            foreach (int neighborIndex in Links[itemIndex]) {
                neighbors.Add(Items[neighborIndex]);
            }
            return neighbors;
        }

        private void Remove(int itemIndex) {
            foreach (var linkList in Links) {
                linkList.Remove(itemIndex);
            }
            Links.RemoveAt(itemIndex);
            this.Items.RemoveAt(itemIndex);
        }

        public int Count {
            get { return Items.Count; }
        }

        public List<T> Items { get; private set; }

        /// <summary>
        /// Adjacency list.
        /// </summary>
        public List<List<int>> Links { get; private set; }
    }
}
