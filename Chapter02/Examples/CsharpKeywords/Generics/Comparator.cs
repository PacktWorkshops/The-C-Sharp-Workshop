using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter02.Examples.CsharpKeywords.Generics
{
    public static class Comparator
    {
        public static bool IsFirstBigger1(IComparable first, IComparable second)
        {
            return first.CompareTo(second) > 0;
        }

        public static bool IsFirstBigger2<T>(T first, T second)
            where T : IComparable
        {
            return first.CompareTo(second) > 0;
        }

        public static IComparable Max1(IComparable first, IComparable second)
        {
            return first.CompareTo(second) > 0
                ? first
                : second;
        }

        public static T Max2<T>(T first, T second)
            where T : IComparable
        {
            return first.CompareTo(second) > 0
                ? first
                : second;
        }
    }
}
