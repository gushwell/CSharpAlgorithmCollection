using System;
using System.Linq;

namespace GetCombination {
    class Program {
        static void Main(string[] args) {
            int n = 5;
            int k = 3;
            var nums = Enumerable.Range(1, n).ToArray();
            var combinations = Combination.Enumerate(nums, k, withRepetition: false);

            int i = 1;
            foreach (var elem in combinations) {
                string s = "(" + string.Join(",", elem.Select(x => x.ToString()).ToArray()) + ")";
                Console.WriteLine("{0} : {1}", i++, s);
            }
        }
    }
}
