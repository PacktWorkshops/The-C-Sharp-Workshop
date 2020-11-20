using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter02.Exercises.Exercise03
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
