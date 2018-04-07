using System;
using System.Linq;

namespace EnumerateKaprekarNumber {
    class Program {
        static void Main(string[] args) {
            var kaprekars = KaprekarNumber.Enumerate();
            foreach (var n in kaprekars.Take(50)) {
                Console.WriteLine(n);
            }
        }
    }
}
