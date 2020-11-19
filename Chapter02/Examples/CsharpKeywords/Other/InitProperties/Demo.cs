using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
