using System;

namespace Chapter02.Activities.Activity01
{
    public struct Circle
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Space => Math.PI * Radius * Radius;

        public static Circle operator +(Circle circle1, Circle circle2)
        {
            var newSpace = circle1.Space + circle2.Space;
            var newRadius = Math.Sqrt((newSpace / Math.PI));

            return new Circle(newRadius);
        }
    }
}
