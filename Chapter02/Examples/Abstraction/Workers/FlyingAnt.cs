using System;

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
