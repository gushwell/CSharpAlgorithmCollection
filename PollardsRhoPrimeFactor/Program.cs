using System;

namespace PollardsRhoPrimeFactor {
    class Program {
        static void Main(string[] args) {
            var primeFactor = new PrimeFactor();
            var factors = primeFactor.Enumerate(54286473);
            foreach (var n in factors)
                Console.WriteLine(n);
        }
    }
}
