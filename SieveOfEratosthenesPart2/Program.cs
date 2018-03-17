using System;
using System.Collections.Generic;
using System.Linq;

namespace SieveOfEratosthenesPart2 {
    class Program {
        static void Main(string[] args) {
            foreach (var n in Primes(100000))
                Console.Write("{0,3} ", n);
            Console.WriteLine();
            Console.ReadLine();
        }

        static IEnumerable<int> Primes(int maxnum) {
            yield return 2;
            yield return 3;
            var sieve = new System.Collections.BitArray(maxnum + 1);
            int squareroot = (int)Math.Sqrt(maxnum);
            for (int i = 2; i <= squareroot; i++) {
                if (sieve[i] == false) {
                    for (int n = i * 2; n <= maxnum; n += i)
                        sieve[n] = true;
                }
                for (int n = i * i + 1; n <= maxnum && n < (i + 1) * (i + 1); n++) {
                    if (!sieve[n])
                        yield return n;
                }
            }
        }
    }
}
