using System;

namespace Chapter02.Exercises.Exercise01
{
    public class Circle
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