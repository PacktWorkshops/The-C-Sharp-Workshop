using System;

namespace Chapter02.Examples.Abstraction.Workers
{
    public class Drone : IFlyer, IWorker
    {
        public void Fly()
        {
            Console.WriteLine("Flying");
        }

        public void Work()
        {
            Console.WriteLine("Working");
        }
    }
}
