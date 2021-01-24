using System;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter05.Examples
{
    class TaskExamples
    {
        
        public static void Main()
        {
            Logger.Log("Creating taskA");
            var taskA = new Task(() =>
            {
                Logger.Log("Inside taskA");
                Thread.Sleep(TimeSpan.FromSeconds(5D));
                Logger.Log("Leaving taskA");
            });
            Logger.Log($"Starting taskA. Status={taskA.Status}");
            taskA.Start();
            Logger.Log($"Started taskA. Status={taskA.Status}");
            Console.ReadLine();

            var taskB = Task.Factory.StartNew((() =>
            {
                Logger.Log("Inside taskB");
                Thread.Sleep(TimeSpan.FromSeconds(3D));
                Logger.Log("Leaving taskB");
            }));
            Logger.Log($"Started taskB. Status={taskB.Status}");
            Console.ReadLine();

            var taskC = Task.Run(() =>
            {
                Logger.Log("Inside taskC");
                Thread.Sleep(TimeSpan.FromSeconds(1D));
                Logger.Log("Leaving taskC");
            });
            Logger.Log($"Started taskC. Status={taskC.Status}");
            Console.ReadLine();
        }

    }
}
