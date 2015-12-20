using System.Collections.Generic;

namespace hw2 {
    /// <summary>
    /// Represents one unit of the Network.
    /// Can send, handle messages and output info about itself.
    /// </summary>
    public class Computer {

        public Computer(OpSystem os) {
            OS = os;
            messages = new Queue<IMessage>();
        }

        public Computer(OpSystem os, ComputerState initState)
            : this(os) {

            State = initState;
        }

        /// <summary>
        /// Send message to other computers.
        /// </summary>
        /// <returns></returns>
        public IMessage SendMessage() {
            return State.SendMessage();
        }

        /// <summary>
        /// Handle received messages.
        /// </summary>
        public void HandleMessages(ProbabilityLogic randomizer) {
            State = State.HandleMessages(messages, os, randomizer);
        }

        /// <summary>
        /// Receives message from other computer.
        /// </summary>
        /// <param name="msg"></param>
        public void AddMessage(IMessage msg) {
            messages.Enqueue(msg);
        }

        /// <summary>
        /// Output computer state to the console.
        /// Delegates this function to the State.
        /// </summary>
        /// <param name="info"></param>
        public void OutputInfo(string info) {
            State.OutputInfo(info);
        }

        public ComputerState State { get; private set; }

        /// <summary>
        /// Available Operating Systems.
        /// </summary>
        public enum OpSystem { Linux = 50, MacOS = 40, Windows = 10, OS_1337 = 100, YourOS = 0 }

        public OpSystem OS {
            get {
                return os;
            }
            set {
                os = value;
                State = new ComputerState();
            }
        }

        OpSystem os;

        /// <summary>
        /// Received messages.
        /// </summary>
        Queue<IMessage> messages;
    }
}
