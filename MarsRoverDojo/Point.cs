using System;
using System.Dynamic;
using System.Xml.Schema;

namespace MarsRoverDojo
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        private int XMax { get; }
        private int YMax { get; }

        public Point(int x, int y, int xMax = 200, int yMax = 200)
        {
            X = x;
            Y = y;
            XMax = xMax;
            YMax = yMax;
        }

        public override bool Equals(Object obj)
        {
            Point pointCompared = obj as Point;
            
            if (pointCompared == null)
            {
                return false;
            }

            return (X == pointCompared.X && Y == pointCompared.Y) ;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode();
        }

        public void MoveLeft()
        {
            if (X == -XMax)
            {
                X = XMax;
            }
            else
            {
                X--;
            }
        }

        public void MoveDown()
        {
            if (Y == -YMax)
            {
                Y = YMax;
            }
            else
            {
                Y--;
            }
        }

        public void MoveRight()
        {
            if (X == XMax)
            {
                X = -XMax;
            }
            else
            {
                X++;
            }
        }

        public void MoveUp()
        {
            if (Y == YMax)
            {
                Y = -YMax;
            }
            else
            {
                Y++;
            }
        }
    }
}