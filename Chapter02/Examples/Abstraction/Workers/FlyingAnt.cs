using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter02.Examples.Abstraction.Workers
{
    public class FlyingAnt : Ant, IFlyer
    {
        public void Fly()
        {
            Console.WriteLine("Flying");
        }
    }
}
