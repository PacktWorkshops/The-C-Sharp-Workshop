using System;

namespace Chapter02.Exercises.Exercise02
{
    public class Circle : IShape
    {
        private readonly double _radius;

        public Circle(double radius)
        {
            _radius = radius;
        }

        public double Space
        {
            get { return Math.PI * _radius * _radius; }
        }
    }
}