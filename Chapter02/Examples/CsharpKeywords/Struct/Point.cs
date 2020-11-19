using System;

namespace Chapter02.Examples.CsharpKeywords.Struct
{
    public readonly struct Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double DistanceTo(Point p)
        {
            return DistanceBetween(this, p);
        }

        public static double DistanceBetween(Point p1, Point p2)
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }
    }
}
