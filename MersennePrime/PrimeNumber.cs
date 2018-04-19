using System;
using System.Linq;
using System.Numerics;

namespace MersennePrime {
    public static class PrimeNumber {

        static long[] seedPrimes = {
          /*1,2,3,4, 5, 6, 7  8, 9,10,11,12,13,14,15,*/
            2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67,71,73,79,83,89,97
        };

        public static bool IsPrime(long num) {
            if (num == 1)
                return false;
            if (seedPrimes.Contains(num))
                return true;
            if (seedPrimes.Any(x => num % x == 0))
                return false;

            return (num < 2000000) ? IsPrimeBruteforce(num) : IsPrimeMillarRrabin(num);
        }

        private static bool IsPrimeBruteforce(long num) {
            if (num == 1)
                return false;
            if (num != 2 && num % 2 == 0)
                return false;
            if (num != 3 && num % 3 == 0)
                return false;
            if (num != 5 && num % 5 == 0)
                return false;
            long i = 0;
            while (true) {
                foreach (var p in seedPrimes.Skip(3).Take(8)) {
                    // 30m+2, 30m+3, 30m+4, 30m+5, 30m+6、30m+8、30m+9、30m+12... は割る必要はない。
                    var primeCandidte = p + i;
                    if (primeCandidte > Math.Sqrt(num))
                        return true;
                    if (num % (primeCandidte) == 0)
                        return false;
                }
                i += 30;
            }
        }

        private static bool IsPrimeMillarRrabin(long num) {
            if (num <= 1)
                return false;
            if ((num & 1) == 0)
                return num == 2;

            if (num < 100 && seedPrimes.Contains((int)num))
                return true;

            var WitnessMax = GetWitnessMax(num);

            long d = num - 1;
            long s = 0;
            while ((d & 1) == 0) {
                s++;
                d >>= 1;
            }
            foreach (var w in seedPrimes.Take(WitnessMax)) {
                if (!MillarRrabin(num, s, d, w))
                    return false;
            }
            return true;
        }


        private static int GetWitnessMax(long num) {
            if (num < 2047)
                return 1;
            if (num < 1373653)
                return 2;
            if (num < 25326001)
                return 3;
            if (num < 3215031751)
                return 4;
            if (num < 2152302898747)
                return 5;
            if (num < 3474749660383)
                return 6;
            if (num < 341550071728321)
                return 7;
            if (num < 3825123056546413051)
                return 9;
            return 12;
        }


        private static bool MillarRrabin(long num, long s, long d, long witness) {
            long x = ModPow(witness, d, num);
            if (x == 1)
                return true;
            for (long r = 0; r < s; r++) {
                if (x == num - 1)
                    return true;
                BigInteger rem;
                BigInteger.DivRem(BigInteger.Multiply(x, x), num, out rem);
                x = (long)(rem);
            }
            return false;
        }

        private static long ModPow(long baseValue, long exponent, long modulus) {
            return (long)BigInteger.ModPow(baseValue, exponent, modulus);
        }

    }
}
