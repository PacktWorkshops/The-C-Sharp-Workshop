using System;
using System.Threading;

namespace Examples.Chapter05
{
    class ExplicitThreadsExample
    {
        public static void Main()
        {
            var threadA = new Thread(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(10));
                Console.WriteLine($"Inside threadA");
                // do something long running
                Thread.Sleep(TimeSpan.FromSeconds(20));
                Console.WriteLine($"Leaving threadA");
            });

            var threadB = new Thread(o =>
            {
                Console.WriteLine($"Inside threadB: o={o}");
                // do something long running
            });

            Console.WriteLine("Starting threads");
            threadA.Start();
            threadB.Start("Hello");

            ThreadPool.QueueUserWorkItem(state =>
            {
                Console.WriteLine($"Inside threadPool: state={state}");
            });


            Console.WriteLine("Press ENTER to quit");
            Console.ReadLine();
        }
    }
}
