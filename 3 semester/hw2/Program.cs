using System;
using System.Collections.Generic;

namespace hw2 {
    static class Program {
        static void Main() {
            var net = new Network();
            net.RandomInit(10);
            net.Run();
        }
    }
}
