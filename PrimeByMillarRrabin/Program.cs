using System;

namespace PrimeByMillarRrabin {
    
    class Program {
        static void Main(string[] args) {
            for (var i = 1990000; i < 2010000; i++) {
                var isPrime = PrimeNumber.IsPrime(i);
                if (isPrime)
                    Console.WriteLine(i);
            }
        }
    }
}
