using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4 {
    class ActionHistory {
        public ActionHistory() {
            history = new List<IAction>();
            current = -1;
        }

        public ActionHistory(ICollection<IAction> history) {
            this.history = new List<IAction>(history);
            current = history.Count - 1;
        }

        public IAction Undo() {
            if (current > -1) {
                current -= 1;
                return history[current + 1];
            } else {
                return new VoidAction();
            }
        }

        public IAction Redo() {
            if (current < history.Count - 1) {
                current += 1;
                return history[current];
            } else {
                return new VoidAction();
            }
        }

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
        }

        private List<IAction> history;
        private int current;
    }
}
