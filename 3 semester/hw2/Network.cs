using System;
using System.Collections.Generic;

namespace hw2 {
    class Network {
        public Network() {
            network = new Graph<Computer>();
            probLogic = new ProbabilityLogic();
        }

        public Network(ICollection<Computer> computers, List<List<int>> links) : this() {
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
                switch (probLogic.Randomizer.Next(0,3)) {
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

        public void Run() {
            string control = "n";
            OutputNetwork();
            while (!IsWholeNetworkInfected()) {
                Console.WriteLine();
                ExecuteStep();
                Console.WriteLine("Continue? (y/n)");
                if (Console.ReadLine().ToLower() == control) {
                    break;
                }
            }
        }

        public void ExecuteStep() {
            SendMessagesStep();
            HandleMessagesStep();
            OutputNetwork();
        }

        public bool IsWholeNetworkInfected() {
            foreach (var computer in network.Items) {
                if (!(computer.State is InfectedState)) {
                    return false;
                }
            }
            return network.Items.Count > 0;
        }

        public void OutputNetwork() {
            for (int i = 0; i < network.Count; ++i) {
                network.Items[i].OutputInfo(i.ToString());
                Console.Write("    Neighbors:");
                foreach (var link in network.Links[i]) {
                    Console.Write(" " + link);
                }
                Console.WriteLine();
            }
        }

        private void SendMessagesStep() {
            for (int i = 0; i < network.Count; ++i) {
                var server = network.Items[i];
                foreach (var client in network.GetNeighbors(i)) {
                    client.AddMessage(server.SendMessage());
                }
            }
        }
        private void HandleMessagesStep() {
            foreach (var computer in network.Items) {
                computer.HandleMessages(probLogic);
            }
        }
        
        /// <summary>
        /// Logical modul.
        /// </summary>
        private ProbabilityLogic probLogic;
        private Graph<Computer> network;
    }
}
