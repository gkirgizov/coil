using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using hw2;

namespace testHW2 {
    [TestClass]
    public class NetworkTests {
        [TestInitialize]
        public void Init() {

            computers = new List<Computer>(5);
            links = new List<List<int>>(4);

            int clearComputers = 4;
            for (; clearComputers > 0; --clearComputers) {
                computers.Add(new Computer(Computer.OpSystem.Windows));
                links.Add(new List<int>());
            }

            // 4 компа соединены замкнутой цепью, один обособлен - он заражен.
            computers.Add(new Computer(Computer.OpSystem.Windows, new InfectedState()));
            links[0].Add(1);
            links[0].Add(3);
            links[1].Add(2);
            links[2].Add(3);

            net = new Network(computers, links);
        }

        [TestMethod]
        public void IsWholeNetworkInfectedTest() {
            // Проверяем инициализированную сеть.
            Assert.IsFalse(net.IsWholeNetworkInfected());

            // Проверяем полностью зараженную сеть.
            computers.Clear();
            int infectedComputers = 5;
            for (; infectedComputers > 0; --infectedComputers) {
                computers.Add(new Computer(Computer.OpSystem.Windows, new InfectedState()));
            }

            net = new Network(computers, links);
            Assert.IsTrue(net.IsWholeNetworkInfected());
        }

        [TestMethod]
        public void IsNetworkStableTest() {
            Assert.IsTrue(net.IsNetworkStable());

        }

        List<List<int>> links;
        List<Computer> computers;
        Network net;
    }
}
