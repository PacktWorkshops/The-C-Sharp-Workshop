using System;

namespace Chapter02.Examples.CsharpKeywords.Other.InitProperties
{
    public class House
    {
        public string Address { get; init; }
        public string Owner { get; init; }
        public DateTime? Built { get; init; }
    }
}
