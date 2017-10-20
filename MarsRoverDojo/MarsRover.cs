using System;
using System.Collections.Generic;

namespace MarsRoverDojo
{
    public class MarsRover
    {
        public Point Point { get; set; }
        public Direction Direction { get; set; }
        public List<Point> Obstacles { get; set; }

        public MarsRover(int x, int y, Direction direction, List<Point> obstacles = null)
        {
            Point = new Point(x, y);
            Direction = direction;

            if (obstacles == null)
            {
                obstacles = new List<Point>();
            }
            
            Obstacles = obstacles;
        }

        private Point PositionAfterForward()
        {
            Point pointMoved = new Point(Point.X, Point.Y);
            
            switch (Direction)
            {
                case Direction.North:
                    pointMoved.MoveUp();
                    break;
                case Direction.East:
                    pointMoved.MoveRight();
                    break;
                case Direction.South:
                    pointMoved.MoveDown();
                    break;
                case Direction.West:
                    pointMoved.MoveLeft();
                    break;
                default: 
                    throw new Exception("Direction unknown");
            }

            return pointMoved;
        }
        
        public void GoForward()
        {
            Point futurePoint = PositionAfterForward();
            MoveWithoutObstacle(futurePoint);
        }

        private void MoveWithoutObstacle(Point futurePoint)
        {
            if(!Obstacles.Contains(futurePoint))
                Point = futurePoint;
        }

        private Point PositionAfterBack()
        {
            Point pointMoved = new Point(Point.X, Point.Y);
            
            switch (Direction)
            {
                case Direction.North:
                    pointMoved.MoveDown();
                    break;
                case Direction.East:
                    pointMoved.MoveLeft();
                    break;
                case Direction.West:
                    pointMoved.MoveRight();
                    break;
                case Direction.South:
                    pointMoved.MoveUp();
                    break;
                default:
                    throw new Exception();
            }

            return pointMoved;
        }

        public void GoBack()
        {
            Point futurePoint = PositionAfterBack();
            MoveWithoutObstacle(futurePoint);
        }

        public void TurnLeft()
        {
            switch (Direction)
            {
                case Direction.North:
                    Direction = Direction.West;
                    break;
                case Direction.West:
                    Direction = Direction.South;
                    break;
                case Direction.South:
                    Direction = Direction.East;
                    break;
                case Direction.East:
                    Direction = Direction.North;
                    break;
                default:
                    throw new Exception("Direction unknown");
            }
        }

        public void TurnRight()
        {
            switch (Direction)
            {
                case Direction.North:
                    Direction = Direction.East;
                    break;
                case Direction.West:
                    Direction = Direction.North;
                    break;
                case Direction.South:
                    Direction = Direction.West;
                    break;
                case Direction.East:
                    Direction = Direction.South;
                    break;
                default:
                    throw new Exception("Direction unknown");
            }
        }

        public void ExecuteCommand(string command)
        {
            foreach (char move in command)
            {
                ExecuteMove(move);
            }
        }

        private void ExecuteMove(char move)
        {
            switch (move)
            {
                case 'F':
                    GoForward();
                    break;
                case 'B':
                    GoBack();
                    break;
                case 'L':
                    TurnLeft();
                    break;
                case 'R':
                    TurnRight();
                    break;
                default:
                    throw new Exception("Move unknown");
            }
        }
    }

    public enum Direction
    {
        North,
        East,
        South,
        West
    }
}