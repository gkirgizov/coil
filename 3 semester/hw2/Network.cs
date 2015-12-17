using System;
using System.Collections.Generic;

namespace hw2 {
    /// <summary>
    /// The main app entity.
    /// Implements app logic concerning network work.
    /// </summary>
    public class Network {

        public Network(ProbabilityLogic logic = null) {
            network = new Graph<Computer>();
            probLogic = logic ?? new ProbabilityLogic();
        }

        public Network(ICollection<Computer> computers,
            List<List<int>> links,
            ProbabilityLogic logic = null) : this(logic) {

            network = new Graph<Computer>(computers, links);
        }

        /// <summary>
        /// Randomly initialize network.
        /// </summary>
        /// <param name="numComputers"></param>
        public void RandomInit(int numComputers) {
            var newComputers = new List<Computer>(numComputers);

            for (int i = 0; i < numComputers; ++i) {
                // Random OS for computer.
                Computer.OpSystem newOS;
                switch (probLogic.Randomizer.Next(0, 3)) {
                    case 1:
                        newOS = Computer.OpSystem.MacOS;
                        break;
                    case 2:
                        newOS = Computer.OpSystem.Windows;
                        break;
                    default:
                        newOS = Computer.OpSystem.Linux;
                        break;
                }

                // Random initial state for computer.
                ComputerState newState;
                switch (probLogic.Randomizer.Next(0, 3)) {
                    case 0:
                        newState = new InfectedState();
                        break;
                    default:
                        newState = new ComputerState();
                        break;
                }
                newComputers.Add(new Computer(newOS, newState));
            }

            network = new Graph<Computer>(newComputers);

            // Create random links between computers.
            for (int j = 0; j < numComputers; ++j) {
                for (int i = 0; i < probLogic.Randomizer.Next(1, numComputers - 1); ++i) {
                    network.AddEdge(j, probLogic.Randomizer.Next(numComputers));
                }
            }
        }

        /// <summary>
        /// Start network.
        /// </summary>
        public void Run() {
            const string control = "n";
            OutputNetwork();
            while (!IsNetworkStable()) {
                Console.WriteLine();
                ExecuteStep();
                Console.WriteLine("Continue? (y/n)");
                if (Console.ReadLine().ToLower() == control) {
                    break;
                }
            }
        }

        /// <summary>
        /// Executes one step of sending and handling messages between computers.
        /// </summary>
        public void ExecuteStep() {
            SendMessagesStep();
            HandleMessagesStep();
            OutputNetwork();
        }

        public bool IsWholeNetworkInfected() {
            for (var iter = network.GetGraphEnumerator(); iter.MoveNext();) {
                if (!(iter.Current.State is InfectedState)) {
                    return false;
                }
            }
            return network.Count > 0;
        }

        public bool IsNetworkStable() {
            for (var iter = network.GetGraphEnumerator(); iter.MoveNext();) {
                if (iter.Current.State is InfectedState) {
                    foreach (var neighbor in iter.GetNeighbors()) {
                        if (!(neighbor.State is InfectedState)) {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Outputs network state.
        /// </summary>
        public void OutputNetwork() {
            for (var iter = network.GetGraphEnumerator(); iter.MoveNext();) {
                iter.Current.OutputInfo(iter.CurrentIndex.ToString() + " - " + iter.Current.OS);
                Console.Write("    Neighbors:");
                foreach (var neighbor in iter.GetNeighborsIndexes()) {
                    Console.Write(" " + neighbor);
                }
                Console.WriteLine();
            }
        }

        private void SendMessagesStep() {
            for (var serverIter = network.GetGraphEnumerator(); serverIter.MoveNext();) {
                foreach (var client in serverIter.GetNeighbors()) {
                    client.AddMessage(serverIter.Current.SendMessage());
                }
            }
        }
        private void HandleMessagesStep() {
            for (var serverIter = network.GetGraphEnumerator(); serverIter.MoveNext();) {
                serverIter.Current.HandleMessages(probLogic);
            }
        }

        /// <summary>
        /// Logical modul.
        /// </summary>
        private ProbabilityLogic probLogic;
        private Graph<Computer> network;
    }
}
