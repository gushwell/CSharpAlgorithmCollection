using System;
using System.Collections.Generic;

namespace MazeDepthFirstSearch {
    class Viewer : IObserver<Direction> {
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

        // 状態が変化した （引数 d には、動いた方向が渡ってくる)
        public void OnNext(Direction d) {
            // d方向に一つ動いた位置を新しい位置にする
            _current = Maze.GetPosition(_current, d);
            // 絶対位置を求め
            var pos = _maze.GetAbsolutePosition(_current);
            // 足跡を残す
            Console.SetCursorPosition(pos.X, pos.Y);
            Console.Write('.');
            Console.SetCursorPosition(pos.X, pos.Y);
            System.Threading.Thread.Sleep(100);
        }

        public void Replay(IEnumerable<Direction> path) {
            var current = new Position { X = 0, Y = 0 };
            foreach (var d in path) {
                current = Maze.GetPosition(current, d);
                var pos = _maze.GetAbsolutePosition(current);
                Console.SetCursorPosition(pos.X, pos.Y);
                Console.Write('.');
                Console.SetCursorPosition(pos.X, pos.Y);
                System.Threading.Thread.Sleep(0);
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
