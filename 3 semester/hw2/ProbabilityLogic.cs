using System;

namespace hw2 {
    class ProbabilityLogic {
        public ProbabilityLogic(int seed = 0) {
            Randomizer = seed == 0 ? new Random() : new Random(seed);
        }

        public bool IsStateChanges(double overallStability, double mean = 0.5, double stdev = 0.5) {
            var result = Randomizer.NextGaussian(mean, stdev) * (1 - overallStability);
            return result > 0.5;
        }

        public Random Randomizer { get; }
    }
}
