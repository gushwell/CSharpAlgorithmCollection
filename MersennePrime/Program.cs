using System;

namespace MersennePrime {
    class Program {
        static void Main(string[] args) {
            var q = PerfectNumber.Take(8);
            foreach (var n in q) {
                Console.WriteLine(n);
            }
        }
    }
}
