using System;
using System.Linq;

namespace GetDerangements {
    class Program {
        static void Main(string[] args) {
            int n = 4;
            var nums = Enumerable.Range(1, n).ToArray();
            var derangements = Derangement.Enumerate(nums);

            int i = 1;
            foreach (var elem in derangements) {
                string s = "(" + string.Join(",", elem.Select(x => x.ToString()).ToArray()) + ")";
                Console.WriteLine("{0} : {1}", i++, s);
            }
        }
    }
}
