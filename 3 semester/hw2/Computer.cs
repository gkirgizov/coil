using System;
using System.Collections.Generic;

namespace hw2 {
    class Computer {
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
        /// Receives messages from other computers.
        /// </summary>
        /// <param name="msg"></param>
        public void AddMessage(IMessage msg) {
            messages.Enqueue(msg);
        }

        public void OutputInfo(string info) {
            State.Draw(info);
        }

        public ComputerState State { get; private set; }

        public enum OpSystem { Linux = 50, MacOS = 40, Windows = 10 }
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
