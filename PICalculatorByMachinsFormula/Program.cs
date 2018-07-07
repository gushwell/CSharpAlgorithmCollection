using System;

namespace PICalculatorByMachinsFormula {
    class Program {
        static void Main(string[] args) {
            string pi = PICalculator.Calculate(1000000);
            Console.WriteLine(PICalculator.Format(pi));
        }
    }
}
