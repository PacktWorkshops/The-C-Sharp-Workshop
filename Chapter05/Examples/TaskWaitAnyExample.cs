using System;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter05.Examples
{
    class TaskWaitAnyExample
    {
        
        public static void Main()
        {

            var outerTask = Task.Run( () =>
            {
                Logger.Log("Inside outerTask");
                var inner1 = Task.Run(() =>
                {
                    Logger.Log("Inside inner1");
                    Thread.Sleep(TimeSpan.FromSeconds(3D));
                });
                var inner2 = Task.Run(() =>
                {
                    Logger.Log("Inside inner2");
                    Thread.Sleep(TimeSpan.FromSeconds(2D));
                });

                Logger.Log("Calling WaitAny on outerTask");
                var doneIndex = Task.WaitAny(inner1,inner2);
                Logger.Log($"Waitany index={doneIndex}");
            });

            Logger.Log("Press ENTER");
            Console.ReadLine();
        }

    }
}
