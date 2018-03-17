using System;
using System.Collections.Generic;
using System.Linq;

namespace SieveOfEratosthenesPart1 {
    class Program {
        static void Main(string[] args) {
            foreach (var n in Primes(100000))
                Console.Write("{0,3} ", n);
            Console.WriteLine();
            Console.ReadLine();
        }

        static IEnumerable<int> Primes(int maxnum) {
            bool[] sieve = Enumerable.Repeat(true, maxnum + 1).ToArray();
            int squareroot = (int)Math.Sqrt(maxnum);
            for (int i = 2; i <= squareroot; i++) {
                if (sieve[i] == false)
                    continue;
                for (int n = i * 2; n <= maxnum; n += i)
                    sieve[n] = false;
            }
            for (int i = 2; i <= maxnum; i++)
                if (sieve[i] == true)
                    yield return i;
        }
    }
}
