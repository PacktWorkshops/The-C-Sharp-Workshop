using System;

namespace Chapter02.Exercises.Exercise03
{
    public static class Solution
    {
        public static void Main()
        {
            var isEnough1 = IsEnough(0, new IShape[0]);
            var isEnough2 = IsEnough(1, new[] { new Rectangle(1, 1) });
            var isEnough3 = IsEnough(100, new IShape[] { new Circle(5) });
            var isEnough4 = IsEnough(5, new IShape[]
            {
                new Rectangle(1, 1), new Circle(1), new Rectangle(1.4,1)
            });

            Console.WriteLine($"IsEnough1 = {isEnough1}, " +
                              $"IsEnough2 = {isEnough2}, " +
                              $"IsEnough3 = {isEnough3}, " +
                              $"IsEnough4 = {isEnough4}.");
        }

        public static bool IsEnough(double mosaicArea, IShape[] tiles)
        {
            double totalArea = 0;
            foreach (var tile in tiles)
            {
                totalArea += tile.Area;
            }

            const double tolerance = 0.0001;
            return totalArea - mosaicArea >= -tolerance;
        }
    }
}
