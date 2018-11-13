using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MazeSolverWavelikeSearch {
    public class Maze {
        private const int Goal = -2;
        private const int Wall = -3;
        private const int Road = -1;
        private const int Mark = -4;
        private int[,] _map;
        private int _xSize;
        private int _ySize;

        // コンストラクタ
        private Maze() {
        }

        // コンストラクタ
        public Maze(string mapfile) {
            ReadMap(mapfile);
        }

        // Mapデータを読み込む
        public void ReadMap(string mapfile) {
            string[] data = File.ReadAllLines(mapfile);
            this._map = new int[data.Length, data[0].Length];
            for (int x = 0; x < data.Length; x++) {
                for (int y = 0; y < data[0].Length; y++) {
                    if (data[x][y] == 'S')
                        this._map[x, y] = 0;
                    else if (data[x][y] == 'G')
                        this._map[x, y] = Goal;
                    else if (data[x][y] == '*')
                        this._map[x, y] = Wall;
                    else
                        this._map[x, y] = Road;
                }
            }
            _xSize = data.Length;
            _ySize = data[0].Length;
        }

        // 複製を作成する
        public Maze Clone() {
            Maze maze = new Maze();
            maze._map = (int[,])_map.Clone();
            maze._xSize = this._xSize;
            maze._ySize = this._ySize;
            return maze;
        }

        // 足跡を付ける
        public void FootMark(Position pos, int step) {
            _map[pos.X, pos.Y] = step;
        }

        // すべての位置を列挙する
        public IEnumerable<Position> AllPositions() {
            for (int x = 0; x < _xSize; x++) {
                for (int y = 0; y < _ySize; y++) {
                    yield return new Position { X = x, Y = y };
                }
            }
        }

        // target で指定したマークがある場所を求める。
        public Position FindPosition(int target) {
            return SeachLocations(target).First();
        }

        // stepで示した位置を列挙する。
        public IEnumerable<Position> SeachLocations(int step) {
            return AllPositions().Where(p => _map[p.X, p.Y] == step);
        }

        // posの四方にある道の位置を列挙する
        public IEnumerable<Position> AroundPositions(Position pos) {
            if (pos.Y + 1 < _ySize)
                yield return new Position { X = pos.X, Y = pos.Y + 1 };
            if (pos.X + 1 < _xSize)
                yield return new Position { X = pos.X + 1, Y = pos.Y };
            if (pos.Y > 0)
                yield return new Position { X = pos.X, Y = pos.Y - 1 };
            if (pos.X > 0)
                yield return new Position { X = pos.X - 1, Y = pos.Y };
        }

        // ゴール直前までたどり着いたか。
        public bool IsFin() {
            var pos = FindPosition(Goal);
            return AroundPositions(pos).Any(p => _map[p.X, p.Y] > 0);
        }

        // posの四方にある道の位置を列挙する
        public IEnumerable<Position> AroundRoads(Position pos) {
            return AroundPositions(pos).Where(p => _map[p.X, p.Y] >= -1);
        }

        // 次に移動できる位置を列挙する
        public IEnumerable<Position> NextPositions(Position pos) {
            return AroundPositions(pos).Where(p => _map[p.X, p.Y] == Road);
        }

        // 迷路をConsoleに表示する
        public void Print() {
            // Goalから逆にたどり、Markを置いてゆく
            var pos = FindPosition(Goal);
            pos = AroundRoads(pos).Where(p => _map[p.X, p.Y] > 0).OrderBy(p => _map[p.X, p.Y]).First();
            int step = _map[pos.X, pos.Y];
            _map[pos.X, pos.Y] = Mark;
            while (step > 1) {  // stepが1になるまで繰り返す。
                foreach (var p in AroundRoads(pos)) {
                    if (_map[p.X, p.Y] == step - 1) {
                        pos = p;
                        step = _map[pos.X, pos.Y];
                        _map[pos.X, pos.Y] = Mark;
                        break;
                    }
                }
            }
            // mapをプリント
            for (int x = 0; x < _xSize; x++) {
                for (int y = 0; y < _ySize; y++) {
                    char c = ' ';
                    int v = _map[x, y];
                    c = (v == Wall) ? '*' : (v == 0) ? 'S' : (v == Goal) ? 'G' : (v == Mark) ? '･' : ' ';
                    Console.Write("{0}", c);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // 迷路をConsoleに表示する [Debug用]
        [Conditional("DEBUG")]
        public void DebugPrint() {
            for (int x = 0; x < _xSize; x++) {
                for (int y = 0; y < _ySize; y++) {
                    string s = (_map[x, y] <= -2)
                                ? "***"
                                : (_map[x, y] == -1)
                                    ? "   "
                                    : string.Format("{0,2} ", _map[x, y]);
                    Console.Write(s);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
