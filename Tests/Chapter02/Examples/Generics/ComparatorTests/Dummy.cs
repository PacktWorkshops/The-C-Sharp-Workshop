using System;

namespace Tests.Chapter02.Examples.Generics.ComparatorTests
{
    public class Dummy : IComparable
    {
        public int CompareTo(object? obj)
        {
            return 0;
        }
    }
}