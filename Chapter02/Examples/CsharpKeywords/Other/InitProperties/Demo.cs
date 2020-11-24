using System;

namespace Chapter02.Examples.CsharpKeywords.Other.InitProperties
{
    public static class Demo
    {
        public static void Run()
        {
            var house1 = new House
            {
                Address = "Kings street 4",
                Owner = "King",
                Built = DateTime.Now
            };

            var house2 = new House();
        }
    }
}
