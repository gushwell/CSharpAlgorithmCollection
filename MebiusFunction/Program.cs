using System;
using System.Linq;

namespace MebiusFunction {
    class Program {
        static void Main(string[] args) {
            // 1 - 100 までのメビウス関数を求める
            int upper = 100;
            Mebius mebius = new Mebius(upper);
            for (int i = 1; i <= upper; i++) {
                Console.WriteLine("μ({0}) = {1}", i, mebius[i]);
            }
            Console.ReadLine();
        }
    }
    class Mebius {
        private int[] mebius;
        public Mebius(int maxnum) {
            mebius = Enumerable.Repeat(1, maxnum + 1).ToArray();
            foreach (int p in PrimeNumber.Enumerate().TakeWhile(n => n <= maxnum)) {
                for (int i = p; i <= maxnum; i += p)
                    mebius[i] *= -1;
                int p2 = p * p;
                for (int pp = p2; pp <= maxnum; pp += p2)
                    mebius[pp] = 0;
            }
        }
        public int this[int n] {
            get {
                return mebius[n];
            }
        }
    }
}
