using System;

namespace hw2 {
    /// <summary>
    /// Represents infected state of the computer.
    /// </summary>
    public class InfectedState : ComputerState {

        public InfectedState() {
            stability = 0;
        }

        public override IMessage SendMessage() {
            return new ViralMessage();
        }

        public override void OutputInfo(string info) {
            var oldForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(info + " - Infected");
            Console.ForegroundColor = oldForegroundColor;
        }

        public override double GetStability(Computer.OpSystem os) {
            return ((double)os + (double)stability) / 100;
        }
    }
}
