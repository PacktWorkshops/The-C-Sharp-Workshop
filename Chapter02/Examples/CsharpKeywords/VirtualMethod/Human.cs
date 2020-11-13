using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter02.Examples.CsharpKeywords.VirtualMethod
{
    public class Human
    {
        public virtual void SayHi()
        {
            Console.WriteLine("Hello!");
        }
    }
}
