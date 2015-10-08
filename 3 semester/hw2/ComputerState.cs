using System;
using System.Collections.Generic;
using System.Linq;

namespace hw2 {
    class ComputerState {

        public virtual IMessage SendMessage() {
            return new VoidMessage();
        }
    
        public virtual ComputerState HandleMessages(Queue<IMessage> messages, Computer.OpSystem os, ProbabilityLogic probLogic) {
            
            // Логика обработки одного сообщения.
            var probableStates = new List<ComputerState>();

            while (messages.Count > 0) {
                var nextMsg = messages.Dequeue();
                if (!(nextMsg is VoidMessage) && probLogic.IsStateChanges(GetStability(os))) {
                    probableStates.Add(nextMsg.Execute(this));
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
        public virtual void Draw(string info) {
            Console.WriteLine(info + " - Clear");
        }

        /// <summary>
        /// Ability to resist changes.
        /// </summary>
        public virtual double GetStability(Computer.OpSystem os) {
            return ((double)os + (double)stability) / 100;
        }

        private int stability = 0;
    }
}
