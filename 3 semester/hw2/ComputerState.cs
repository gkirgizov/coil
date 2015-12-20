using System;
using System.Collections.Generic;

namespace hw2 {
    /// <summary>
    /// Represents default state of the computer.
    /// </summary>
    public class ComputerState {
        /// <summary>
        /// Send message. Message content depends on the state
        /// </summary>
        /// <returns></returns>
        public virtual IMessage SendMessage() {
            return new VoidMessage();
        }
    
        /// <summary>
        /// Handle received messages.
        /// </summary>
        /// <param name="messages"></param>
        /// <param name="os"></param>
        /// <param name="probLogic"></param>
        /// <returns></returns>
        public virtual ComputerState HandleMessages(Queue<IMessage> messages, Computer.OpSystem os, ProbabilityLogic probLogic) {
            
            // Логика обработки одного сообщения.
            var probableStates = new List<ComputerState>();

            while (messages.Count > 0) {
                var nextMsg = messages.Dequeue();
                if (!(nextMsg is VoidMessage) && probLogic.IsStateChanges(GetStability(os))) {
                    probableStates.Add(nextMsg.GetMessage(this));
                }
            }

            // Если список состояний пуст - возвращается исходное состояние.
            if (probableStates.Count == 0) {
                return this;
            }

            // Логика обработки сообщений в совокупности. Рандом.
            return probableStates[probLogic.Randomizer.Next(probableStates.Count)];
        }

        /// <summary>
        /// Output computer state to the console.
        /// </summary>
        /// <param name="parent"></param>
        public virtual void OutputInfo(string info) {
            Console.WriteLine(info + " - Clear");
        }

        /// <summary>
        /// Ability to resist changes.
        /// </summary>
        public virtual double GetStability(Computer.OpSystem os) {
            return ((double)os + (double)stability) / 100;
        }

        /// <summary>
        /// One of the possible characteristics of the state.
        /// </summary>
        protected int stability = 0;
    }
}
