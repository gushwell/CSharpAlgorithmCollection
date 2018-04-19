using System;
using System.Collections.Generic;

namespace MersennePrime {
    public class PerfectNumber {
        public static IEnumerable<long> Take(int maxcount) {
            int count = 0;
            long n = 2;
            while (count < maxcount) {
                long mp = (long)Math.Pow(2, n) - 1;
                if (PrimeNumber.IsPrime(mp)) {
                    long pn = (long)(Math.Pow(2, n - 1) * mp);
                    count++;
                    yield return pn;
                }
                n++;
            }
        }
    }
}
