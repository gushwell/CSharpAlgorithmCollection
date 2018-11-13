using System;
using System.Collections.Generic;

namespace MazeBreadthFirstSearch {
    class Viewer : IObserver<Position> {
        private Maze _maze;

        public Viewer(Maze maze) {
            _maze = maze;
            Console.SetCursorPosition(0, 0);
            Print();
        }

        public void OnCompleted() {
        }

        public void OnError(Exception error) {
        }

        private Position _current = new Position { X = 0, Y = 0 };

        // 状態が変化した （引数 relative は、相対位置)
        public void OnNext(Position relative) {
            // 絶対位置を求め
            var pos = _maze.GetAbsolutePosition(relative);
            // 足跡を残す
            Console.SetCursorPosition(pos.X, pos.Y);
            Console.Write('.');
            Console.SetCursorPosition(pos.X, pos.Y);
            System.Threading.Thread.Sleep(100);
        }

        // リプレイする
        public void Replay(IEnumerable<Direction> path) {
            var current = new Position { X = 0, Y = 0 };
            foreach (var d in path) {
                current = Maze.GetPosition(current, d);
                var pos = _maze.GetAbsolutePosition(current);
                Console.SetCursorPosition(pos.X, pos.Y);
                Console.Write('.');
                Console.SetCursorPosition(pos.X, pos.Y);
                System.Threading.Thread.Sleep(80);
            }
            Console.SetCursorPosition(0, _maze.YSize + 1);

        }

        // 迷路をConsoleに表示する
        public void Print() {
            for (int y = 0; y < _maze.YSize; y++) {
                for (int x = 0; x < _maze.XSize; x++) {
                    Console.Write(_maze[x, y]);
                }
                Console.WriteLine();
            }
        }

    }
}
