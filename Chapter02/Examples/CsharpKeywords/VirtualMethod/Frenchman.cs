using System;

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
