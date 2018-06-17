using System;
using System.Collections.Generic;
using System.Linq;

namespace TriangularNumberApp {
    class Program {
        static void Main(string[] args) {
            var nums = TriangularNumber.Take(30);
            int n = 0;
            foreach (var tn in nums) {
                Console.WriteLine($"{n} : {tn}");
                n++;
            }
        }
    }


}
