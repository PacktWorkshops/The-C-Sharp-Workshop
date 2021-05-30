using System;

namespace Chapter02.Exercises.Exercise02
{
    public static class Solution
    {
        public const string Equal = "equal";
        public const string Rectangular = "rectangular";
        public const string Circular = "circular";

        public static void Main()
        {
            // equal
            string compare1 = Solve(new Rectangle[0], new Circle[0]);

            // rectangular
            string compare2 = Solve(new[] { new Rectangle(1, 5) }, new Circle[0]);

            // circular
            string compare3 = Solve(new Rectangle[0], new[] { new Circle(1) });

            // circular
            string compare4 = Solve(new []
            {
                new Rectangle(5.0, 2.1), 
                new Rectangle(3, 3), 
            }, new[]
            {
                new Circle(1),
                new Circle(10), 
            });

            Console.WriteLine($"compare1 is {compare1}, " +
                              $"compare2 is {compare2}, " +
                              $"compare3 is {compare3}, " +
                              $"compare4 is {compare4}.");
        }

        public static string Solve(Rectangle[] rectangularSection, Circle[] circularSection)
        {
            var totalSpaceOfRectangles = CalculateTotalSpaceOfRectangles(rectangularSection);
            var totalSpaceOfCircles = CalculateTotalSpaceOfCircles(circularSection);

            return PickResult(totalSpaceOfRectangles, totalSpaceOfCircles);
        }

        private static double CalculateTotalSpaceOfRectangles(Rectangle[] rectangularSection)
        {
            double totalSpaceOfRectangles = 0;
            foreach (var rectangle in rectangularSection)
            {
                totalSpaceOfRectangles += rectangle.Space;
            }

            return totalSpaceOfRectangles;
        }

        private static double CalculateTotalSpaceOfCircles(Circle[] circularSection)
        {
            double totalSpaceOfCircles = 0;
            foreach (var circle in circularSection)
            {
                totalSpaceOfCircles += circle.Space;
            }

            return totalSpaceOfCircles;
        }

        private static string PickResult(double totalSpaceOfRectangles, double totalSpaceOfCircles)
        {
            const double margin = 0.01;
            bool areAlmostEqual = Math.Abs(totalSpaceOfRectangles - totalSpaceOfCircles) <= margin;
            if (areAlmostEqual)
            {
                return Equal;
            }
            else if (totalSpaceOfRectangles > totalSpaceOfCircles)
            {
                return Rectangular;
            }
            else
            {
                return Circular;
            }
        }
    }
}
