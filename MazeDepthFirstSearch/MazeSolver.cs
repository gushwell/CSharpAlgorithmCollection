using System;
using System.Collections.Generic;
using System.Linq;

namespace MazeDepthFirstSearch {
    // 深さ優先探索
    // 自分がいる絶対的な位置を知ることはできないものとする。
    // スタート位置を(0,0とし、どのように進んだかを自分自身で把握することで
    // 相対的な位置だけはわかる。
    // 迷路についてわかるのは自分の周りが道なのか壁なのかゴールなのかだけとする。
    public class MazeSolver : IObservable<Direction> {
        private Maze _maze;

        // 解く。必ず解が存在することが前提。
        public IEnumerable<Direction> Solve(Maze maze) {
            _maze = maze;
            _footprint.Add(_current);
            _Solve();
            return _path.Reverse();
        }

        // ４つの方向を列挙する （直前の方向を最初にする)
        public IEnumerable<Direction> Directions() {
            if (_lastDirection != Direction.None)
                yield return _lastDirection;
            if (_lastDirection != Direction.South)
                yield return Direction.South;
            if (_lastDirection != Direction.East)
                yield return Direction.East;
            if (_lastDirection != Direction.North)
                yield return Direction.North;
            if (_lastDirection != Direction.West)
                yield return Direction.West;
        }

        private Position _current = new Position { X = 0, Y = 0 };

        private List<Position> _footprint = new List<Position>();

        private Stack<Direction> _path = new Stack<Direction>();

        private Direction _lastDirection = Direction.None;

        // Solveの下請け 再帰的に呼び出される
        private bool _Solve(int level = 0) {
            foreach (var direction in Directions().ToList()) {
                var temp = Maze.GetPosition(_current, direction);
                switch (_maze.Look(temp)) {
                    case Place.Goal:
                        return true;
                    case Place.Start:
                        return false;
                    case Place.Path:
                        if (!AlreadyPassed(temp)) {
                            Walk(direction);
                            if (_Solve(level + 1))
                                return true;
                            Back(direction);
                        }
                        break;
                }
            }
            return false;
        }

        // 指定した方向へ歩く。
        private void Walk(Direction direction) {
            _current = Maze.GetPosition(_current, direction);
            _footprint.Add(_current);
            _path.Push(direction);
            _lastDirection = direction;
            Publish(direction);
        }

        // 逆の方向に戻る。
        public void Back(Direction direction) {
            var dir = Maze.BackDirection(direction);
            _current = Maze.GetPosition(_current, dir);
            Publish(dir);
            _path.Pop();
        }

        // 逆戻りする
        private void TurnBack(Direction direction) {
            while (true) {
                var dir = Maze.BackDirection(_path.Pop());
                Back(dir);
                foreach (var nd in Directions()) {
                    var temp = Maze.GetPosition(_current, nd);
                    if (_maze.Look(temp) == Place.Path && !AlreadyPassed(temp))
                        // その方向が指す場所は、まだ試していない （_footprintにない) なら、もう戻らなくて良い
                        return;
                }
                // 行くべき道がないから、さらに戻る
            }
        }

        // 指定した方向は既に通った場所か
        private bool AlreadyPassed(Position pos) {
            return _footprint.Exists(p => p.X == pos.X && p.Y == pos.Y);
        }

        // このプログラムでは購読者は、Viewerオブジェクトの一つだけ。
        private List<IObserver<Direction>> _observers = new List<IObserver<Direction>>();

        // 終了を通知する
        private void Complete() {
            foreach (var observer in _observers) {
                observer.OnCompleted();
            }
        }

        // 状況変化を知らせるために購読者に通知する
        private void Publish(Direction state) {
            foreach (var observer in _observers) {
                observer.OnNext(state);
            }
        }

        // observer(購読者) が通知を受け取れるようにする
        public IDisposable Subscribe(IObserver<Direction> observer) {
            _observers.Add(observer);
            return observer as IDisposable;
        }
    }
}
