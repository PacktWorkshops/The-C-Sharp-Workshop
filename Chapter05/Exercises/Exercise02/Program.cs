using System;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter05.Exercises.Exercise02
{
    class Program
    {
        public static void Main()
        {
            Logger.Log("Starting");

            var taskA = Task.Run( () =>
            {
                Logger.Log("Inside TaskA");
                Thread.Sleep(TimeSpan.FromSeconds(5));
                Logger.Log("Leaving TaskA");
                return "All done A";
            });
            var taskB = Task.Run(TaskBActivity);
            var taskC = Task.Run(TaskCActivity);

            var timeout = TimeSpan.FromSeconds(new Random().Next(1, 10));
            Logger.Log($"Waiting max {timeout.TotalSeconds} seconds...");
            var allDone = Task.WaitAll(new[] {taskA, taskB, taskC}, timeout);
            Logger.Log($"AllDone={allDone}: TaskA={taskA.Status}, TaskB={taskB.Status}, TaskC={taskC.Status}");

            Console.WriteLine("Press ENTER to quit");
            Console.ReadLine();
        }

        private static string TaskBActivity()
        {
            Logger.Log($"Inside {nameof(TaskBActivity)}");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Logger.Log($"Leaving {nameof(TaskBActivity)}");
            return "";
        }

        private static void TaskCActivity()
        {
            Logger.Log($"Inside {nameof(TaskCActivity)}");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Logger.Log($"Leaving {nameof(TaskCActivity)}");
        }
    }
}
