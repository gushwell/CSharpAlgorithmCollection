using System;
using System.Linq;

namespace PollardsRhoPrimeFactor {
    class Program {
        static void Main(string[] args) {
            var primeFactor = new PrimeFactor();
            var line = Console.ReadLine();
            var num = int.Parse(line);
            var factors = primeFactor.Enumerate(num);
            Console.Write(string.Join(" * ", factors));
        }
    }
}
