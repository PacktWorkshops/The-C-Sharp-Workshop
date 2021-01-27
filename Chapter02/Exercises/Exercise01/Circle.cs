using System;

namespace Chapter02.Exercises.Exercise01
{
    public class Circle
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