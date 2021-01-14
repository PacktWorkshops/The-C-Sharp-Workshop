using System;

namespace Chapter02.Examples.CsharpKeywords.Struct
{
    public static class Demo
    {
        public static void Run()
        {
            var p1 = new Point(1,1);
            var p2 = new Point(3,4);

            Console.WriteLine(p1.Equals(p2));

            var distance1 = p1.DistanceTo(p2);
            var distance2 = Point.DistanceBetween(p1, p2);
        }
    }
}
