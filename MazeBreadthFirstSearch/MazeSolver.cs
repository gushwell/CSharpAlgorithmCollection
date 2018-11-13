using System;
using System.Collections.Generic;
using System.Linq;

namespace MazeBreadthFirstSearch {
    // 幅優先探索で解く
    public class MazeSolver : IObservable<Position> {
        private Maze _maze;

        // 解く。必ず解が存在することが前提。
        public IEnumerable<Direction> Solve(Maze maze) {
            _maze = maze;
            var tracks = _Solve();
            return tracks.GetDirectionPath();
        }

        public Tracks _Solve() {
            Queue<Tracks> queu = new Queue<Tracks>();
            queu.Enqueue(new Tracks());

            while (queu.Count != 0) {
                //キューの先頭から経路情報取り出す
                var tracks = queu.Dequeue();
                var (currentPosition, currentDirection) = tracks.Current;
                foreach (var direction in Directions(currentDirection).ToList()) {
                    // 次に進む位置を求める
                    var nextpos = Maze.GetPosition(currentPosition, direction);
                    // その場所の種類を調べる
                    switch (_maze.Look(nextpos)) {
                        case Place.Goal:
                            return tracks;
                        case Place.Path:
                            if (!AlreadyPassed(tracks, nextpos)) {
                                // 通路でまだ通っていない場所ならば、キューに入れて覚えてく
                                var clone = tracks.Clone();
                                clone.Add(nextpos, direction);
                                queu.Enqueue(clone);
                                Publish(nextpos);
                            }
                            break;
                    }
                    // 壁とStart位置ならば何もせずに、次の方向を調べる
                }
            }
            return null;
        }


        // ４つの方向を列挙する （できるだけ直進するように直前の方向を最初にする)
        public IEnumerable<Direction> Directions(Direction lastDirection) {
            if (lastDirection != Direction.None)
                yield return lastDirection;
            if (lastDirection != Direction.South)
                yield return Direction.South;
            if (lastDirection != Direction.East)
                yield return Direction.East;
            if (lastDirection != Direction.North)
                yield return Direction.North;
            if (lastDirection != Direction.West)
                yield return Direction.West;
        }

        // 指定した方向は既に通った場所か
        private bool AlreadyPassed(Tracks tracks, Position pos) {
            return tracks.GetPositionPathh().Any(p => p.X == pos.X && p.Y == pos.Y);
        }

        // このプログラムでは購読者は、Viewerオブジェクトの一つだけ。
        private List<IObserver<Position>> _observers = new List<IObserver<Position>>();

        // 終了を通知する
        private void Complete() {
            foreach (var observer in _observers) {
                observer.OnCompleted();
            }
        }

        // 状況変化を購読者に通知する
        private void Publish(Position state) {
            foreach (var observer in _observers) {
                observer.OnNext(state);
            }
        }

        // observer(購読者) が通知を受け取れるようにする
        public IDisposable Subscribe(IObserver<Position> observer) {
            _observers.Add(observer);
            return observer as IDisposable;
        }
    }
}
