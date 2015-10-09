using System;

namespace hw2 {
    public class ProbabilityLogic {
        public ProbabilityLogic(double threshold = 0.5, int seed = 0) {
            Randomizer = seed == 0 ? new Random() : new Random(seed);
            Threshold = threshold;
        }

        public bool IsStateChanges(double overallStability, double mean = 0.5, double stdev = 0.5) {
            var result = Randomizer.NextGaussian(mean, stdev) * (1 - overallStability);
            return result > Threshold;
        }

        public Random Randomizer { get; }
        public double Threshold { get; }
    }
}
