using System;
using System.Threading;
using System.Threading.Tasks;

namespace Examples.Chapter05
{
    class FireAndForgetObservedProgram
    {
        public static void Main()
        {
            TaskScheduler.UnobservedTaskException += (sender, args) =>
            {
                Logger.Log($"Caught UnobservedTaskException: {args.Exception}");
            };

            var ops = new FireAndForgetOperations();
            ops.DoStuff();
            ops.DoStuffTask();

            Console.WriteLine("Press Enter to GC.Collect");
            Console.ReadLine();
            ops = null;
            GC.Collect();

            Console.WriteLine("Press Enter to end");
            Console.ReadLine();
        }

        class FireAndForgetOperations
        {
            public void DoStuff()
            {
                Task.Run(BadOperation);
            }

            public Task DoStuffTask()
            {
                return Task.Run(BadOperation);
            }

            private static void BadOperation()
            {
                Logger.Log("BadOperation sleeping...");
                Thread.Sleep(1000);

                Logger.Log("BadOperation awake, throwing...");
                throw new ApplicationException("oops");
            }

        }
    }
}
