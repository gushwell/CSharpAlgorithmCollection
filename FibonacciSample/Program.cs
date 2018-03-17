using System;
using System.Collections.Generic;
using System.Linq;

namespace FibonacciSample {
    class Program {
        static void Main(string[] args) {
            // f(0)..f(50)までを列挙する
            var fibos = Fibonacci.Enumerate()
                                 .Select((Value, Index) => new { Index, Value })
                                 .TakeWhile(x => x.Index <= 50);
            foreach (var f in fibos) {
                Console.WriteLine($"f({f.Index}) = {f.Value}");
            }
        }
    }

    static class Fibonacci {
        public static IEnumerable<long> Enumerate() {
            yield return 0;
            yield return 1;
            // 無限に求める オーバーフローは無視
            long[] array = new long[] { 0, 1 };
            while (true) {
                var fibo = array[0] + array[1];
                array[0] = array[1];
                array[1] = fibo;
                yield return fibo;
            }
        }
    }
}
