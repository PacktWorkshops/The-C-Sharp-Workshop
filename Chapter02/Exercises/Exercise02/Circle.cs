using System;

namespace Chapter02.Exercises.Exercise02
{
    public class Circle
    {
        private readonly double _radius;

        public Circle(double radius)
        {
            _radius = radius;
        }

        public double Area
        {
            get { return Math.PI * _radius * _radius; }
        }
    }
}