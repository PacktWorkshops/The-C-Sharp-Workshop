using System;

namespace Chapter02.Exercises.Exercise02
{
    public class Circle : IShape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Space
        {
            get { return Math.PI * Radius * Radius; }
        }
    }
}