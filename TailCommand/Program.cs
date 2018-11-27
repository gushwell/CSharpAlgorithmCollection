using System;
using System.IO;

namespace TailCommand {
    class Program {
        static void Main(string[] args) {
            int count = 10;
            string filepath = null;
            if (args.Length > 0) {
                if (int.TryParse(args[0], out count) == false) {
                    count = 10;
                    filepath = args[0];
                } else if (args.Length == 2)
                    filepath = args[1];
            }
            DoTail(count, filepath);
        }

        private static void DoTail(int linecount, string filename) {
            using (var tr = string.IsNullOrEmpty(filename)
                                ? Console.In : new StreamReader(filename)) {
                RingBuffer<string> rb = new RingBuffer<string>(linecount);
                string line;
                while ((line = tr.ReadLine()) != null) {
                    rb.Add(line);
                }
                foreach (var s in rb)
                    Console.WriteLine(s);
            }
        }

    }
}
