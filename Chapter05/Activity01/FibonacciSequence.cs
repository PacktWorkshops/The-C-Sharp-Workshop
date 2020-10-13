using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter05.Activity01
{
    public static class FibonacciSequence
    {
        public static IList<Fibonacci> Calculate(int indices, double phi)
        {
            var angle = phi.GoldenAngle();

            var items = new List<Fibonacci>(indices)
            {
                Fibonacci.CreateSeed()
            };

            for (var i = 1; i < indices; i++)
            {
                var previous = items.ElementAt(i - 1);
                var next = Fibonacci.CreateNext(previous, angle);
                items.Add(next);
            }

            return items;
        }
    }

    public static class FibonacciExtensions
    {
        private const double FullCircle = 360D;
        private const double SemiCircle = FullCircle / 2D;

        public static double DegreesToRadians(this double degrees)
        {
            return (Math.PI / SemiCircle) * degrees;
        }

        public static double GoldenAngle(this double phi)
        {
            return FullCircle - (FullCircle / phi);
        }
    }

    public class Fibonacci
    {
        public static Fibonacci CreateSeed()
        {
            return new Fibonacci(1, 0D, 1D);
        }

        public static Fibonacci CreateNext(Fibonacci previous, double angle)
        {
            return new Fibonacci(previous, angle);
        }

        private Fibonacci(int index, double theta, double x)
        {
            Index = index;
            Distance = Math.Sqrt(Index);
            Theta = theta;
            X = x;
            Y = 0D;
        }

        private Fibonacci(Fibonacci previous, double angle)
        {
            Index = previous.Index + 1;
            Distance = Math.Sqrt(Index);
            Theta = previous.Theta + angle;

            var radians = Theta.DegreesToRadians();
            X = Distance * Math.Cos(radians);
            Y = Distance * Math.Sin(radians);
        }

        public int Index { get; }
        public double Distance { get; }
        public double Theta { get; }
        public double X { get; }
        public double Y { get; }
    }
    
}
