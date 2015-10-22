using Microsoft.VisualStudio.TestTools.UnitTesting;
using hw2;

namespace testHW2 {
    [TestClass]
    public class ComputerTests {
        [TestInitialize]
        public void Init() {
            server = new Computer(Computer.OpSystem.OS_1337, new InfectedState());
            client = new Computer(Computer.OpSystem.YourOS, new ComputerState());

            serverMsg = server.SendMessage();
            clientMsg = client.SendMessage();

            // 100% of infection or any state change
            logic = new ProbabilityLogic(double.MinValue);
        }

        [TestMethod]
        public void IsInfectedCompSendViralMsgsTest() {
            Assert.IsTrue(serverMsg is ViralMessage);
        }

        [TestMethod]
        public void IsClearCompSendVoidMsgsTest() {
            Assert.IsTrue(clientMsg is VoidMessage);
        }

        [TestMethod]
        public void HandleViralMessageTest() {
            Assert.IsTrue(serverMsg.GetMessage(client.State) is InfectedState);
            client.AddMessage(serverMsg);
            client.HandleMessages(logic);
            Assert.IsTrue(client.State is InfectedState);
        }

        [TestMethod]
        public void HandleVoidMessageTest() {
            Assert.IsTrue(!(clientMsg.GetMessage(client.State) is InfectedState));
            server.AddMessage(clientMsg);
            server.HandleMessages(logic);
            Assert.IsTrue(server.State is InfectedState);
        }

        ProbabilityLogic logic;
        IMessage serverMsg;
        IMessage clientMsg;
        Computer server;
        Computer client;
    }
}
