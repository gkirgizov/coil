using System.Collections.Generic;

namespace hw4 {
    /// <summary>
    /// Provides undo/redo capabilities by IAction interface.
    /// </summary>
    public class ActionHistory {

        public ActionHistory(int capacity = 100) {
            history = new List<IAction>(capacity);
            current = -1;
            this.capacity = capacity;
        }
        public ActionHistory(ICollection<IAction> history, int capacity = 100) {
            this.history = new List<IAction>(history);
            current = history.Count - 1;
            this.capacity = capacity;
        }

        /// <summary>
        /// Returns previous action.
        /// </summary>
        /// <returns></returns>
        public IAction Undo() {
            if (current > -1) {
                current -= 1;
                return history[current + 1];
            } else {
                return new VoidAction();
            }
        }
        
        /// <summary>
        /// Returns next action.
        /// </summary>
        /// <returns></returns>
        public IAction Redo() {
            if (current < history.Count - 1) {
                current += 1;
                return history[current];
            } else {
                return new VoidAction();
            }
        }

        /// <summary>
        /// Add action to the history.
        /// </summary>
        /// <param name="action"></param>
        public void Log(IAction action) {
            var actions = new List<IAction> { action };
            Log(actions);
        }
        public void Log(ICollection<IAction> actions) {
            if (current > -1 && current < history.Count - 1) {
                history.RemoveRange(current, history.Count - current - 1);
            }
            history.AddRange(actions);
            current += actions.Count;

            if (history.Count > capacity) {
                history.RemoveRange(0, 10);
                current -= 10;
            }
        }


        private List<IAction> history;
        private int current;
        private int capacity;
    }
}
