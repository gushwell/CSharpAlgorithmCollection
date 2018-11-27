using System;
using System.Collections.Generic;

namespace CatCommand {
    class Program {
        static void Main() {
            var reader = new EnumerableTextReader(Console.In);
            reader.ForEach(Console.WriteLine);
        }
    }

    public static class EnumerableExtentions {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action) {
            foreach (T x in source) {
                action(x);
            }
        }
    }
}
