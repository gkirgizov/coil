using System;
using System.Collections.Generic;

namespace hw3 {
    /// <summary>
    /// Is able to determine will robots selfdestruct
    /// within specified or randomly generated graph.
    /// </summary>
    public class RoboExistence {
        public RoboExistence(int fieldSize = 1) {
            this.fieldSize = fieldSize;
            RandomInit();
        }
        public RoboExistence(Graph<bool> field) {
            this.field = field;
        }

        /// <summary>
        /// Randomly initialises graph and returns it for whatever purpose.
        /// </summary>
        /// <param name="seed">Seed for the Random class.</param>
        /// <returns>Generated graph</returns>
        public Graph<bool> RandomInit(int seed = 0) {
            var r = seed == 0 ? new Random() : new Random(seed);

            var robots = new List<bool>(fieldSize);
            for (var i = 0; i < fieldSize; ++i) {
                robots.Add(false);
            }
            var numRobots = r.Next(2, fieldSize / 2);

            for (int i = 0; i < numRobots;) {
                int next = r.Next(fieldSize);
                if (!robots[next]) {
                    robots[next] = true;
                    ++i;
                }
            }

            field = new Graph<bool>(robots);
            for (int j = 0; j < fieldSize; ++j) {
                for (int i = 0; i < r.Next(1, fieldSize - 1); ++i) {
                    field.AddEdge(j, r.Next(fieldSize));
                }
            }
            
            return field;
        }

        /// <summary>
        /// Determine the possibility of selfdestruction of the robots.
        /// </summary>
        /// <returns></returns>
        public bool AreRobotsDie() {
            var bipartition = field.GetBipartition();
            int part1Count = 0;
            int part0Count = 0;

            var i = bipartition.GetEnumerator();
            foreach (var isRobot in field) {
                i.MoveNext();
                if (isRobot) {
                    if (i.Current) {
                        ++part1Count;
                    } else {
                        ++part0Count;
                    }
                }
            }
            return part0Count % 2 == 0 && part1Count % 2 == 0;
        }

        /// <summary>
        /// Outputs graph.
        /// </summary>
        public void PrintRobotsGraph() {
            Console.WriteLine("Robots are in the nodes: ");
            var i = field.GetGraphEnumerator();

            var robots = new List<int>();
            for (; i.MoveNext();) {
                if (i.Current) {
                    robots.Add(i.CurrentIndex);
                }
            }

            i.Reset();
            for (;  i.MoveNext();) {
                Console.WriteLine();
                if (i.Current) {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                Console.Write(i.CurrentIndex + " : ");
                Console.ForegroundColor = ConsoleColor.Gray;

                foreach (var neighbor in i.GetNeighborsIndexes()) {
                    if (robots.Contains(neighbor)) {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    Console.Write(neighbor + " ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine();
            }
        }

        private int fieldSize;
        private Graph<bool> field;
    }
}
