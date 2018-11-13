using System;
using System.Diagnostics;

namespace MazeBreadthFirstSearch {
    class Program {
        static void Main(string[] args) {
            var sw = Stopwatch.StartNew();

            var maze = new Maze("map.txt");
            var v = new Viewer(maze);
            var solver = new MazeSolver();
            // solver.Subscribe(v);
            var ans = solver.Solve(maze);

            sw.Stop();
            v.Replay(ans);
            Console.WriteLine("{0}ミリ秒", sw.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
