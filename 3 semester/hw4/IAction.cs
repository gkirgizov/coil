using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4 {
    interface IAction {
        void Execute();
        void Unexecute();
    }
}
