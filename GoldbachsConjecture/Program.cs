using System;

namespace GoldbachsConjecture {
    class Program {
        static void Main(string[] args) {
            while (true) {
                var str = Console.ReadLine();
                long num;
                if (long.TryParse(str, out num) == false) {
                    Console.Error.WriteLine("入力形式が異なります。6以上の偶数を入力してください。");
                } else if (num % 2 != 0 || num < 6) {
                    Console.Error.WriteLine("6以上の偶数を入力してください。");
                } else {
                    var r = Goldbach.Resolve(num);
                    Console.WriteLine($"{num} = {r[0]} + {r[1]}");
                }
            }
        }
    }

    public static class Goldbach {

        public static long[] Resolve(long num) {
            for (long a = 3; a <= num; a += 2) {
                if (!PrimeNumber.IsPrime(a))
                    continue;
                long b = num - a;
                if (PrimeNumber.IsPrime(b))
                    return new long[] { a, b };
            }
            return new long[] { -1, -1 };
        }
    }

}
