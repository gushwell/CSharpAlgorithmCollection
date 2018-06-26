using System;

namespace GetPermutation2 {
    class Program {
        static void Main(string[] args) {
            var perm = new Permutation();

            // 重複なし
            foreach (var n in perm.Enumerate("ABCD", 3, false)) {
                foreach (var x in n)
                    Console.Write("{0} ", x);
                Console.WriteLine();
            }
            Console.WriteLine();
            // 重複あり
            foreach (var n in perm.Enumerate("ABCD", 3, true)) {
                foreach (var x in n)
                    Console.Write("{0} ", x);
                Console.WriteLine();
            }

        }
    }
}
