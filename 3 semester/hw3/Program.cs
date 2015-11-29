using System;
using System.Collections.Generic;

namespace hw3 {
    class Program {
        static void Main(string[] args) {
            var app = new RoboExistence(6);
            app.RandomInit();
            app.PrintRobotsGraph();
            Console.WriteLine();
            Console.WriteLine(app.AreRobotsDie());
            Console.WriteLine();
        }
    }
}
