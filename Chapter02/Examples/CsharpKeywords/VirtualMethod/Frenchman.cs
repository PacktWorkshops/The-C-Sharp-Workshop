using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter02.Examples.CsharpKeywords.VirtualMethod
{
    public class Frenchman : Human
    {
        public override void SayHi()
        {
            Console.WriteLine("Bonjour!");
        }
    }
}
