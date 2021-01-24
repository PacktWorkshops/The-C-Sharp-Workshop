using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter05.Exercises.Exercise04
{
    public class SlowRunningService
    {

        public Task<double> Fetch(TimeSpan delay, CancellationToken token)
        {
            return Task.Run(() =>
                {
                    var now = DateTime.Now;

                    Logger.Log("Fetch: Sleeping");
                    Thread.Sleep(delay);
                    Logger.Log("Fetch: Awake");

                    return DateTime.Now.Subtract(now).TotalSeconds;
                },
                token);
        }


        public Task<double?> FetchLoop(TimeSpan delay, CancellationToken token)
        {
            return Task.Run(() =>
            {
                const int TimeSlice = 500;
                var iterations = (int)(delay.TotalMilliseconds / TimeSlice);

                Logger.Log($"FetchLoop: Iterations={iterations} token={token.GetHashCode()}");

                var now = DateTime.Now;

                for (var i = 0; i < iterations; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Logger.Log($"FetchLoop: Iteration {i + 1} detected cancellation token={token.GetHashCode()}");
                        //token.ThrowIfCancellationRequested();
                        //break;
                        return (double?)null;
                    }

                    Logger.Log($"FetchLoop: Iteration {i + 1} Sleeping");
                    Thread.Sleep(TimeSlice);
                    Logger.Log($"FetchLoop: Iteration {i + 1} Awake");
                }

                Logger.Log("FetchLoop: done");

                return DateTime.Now.Subtract(now).TotalSeconds;
            }, token);
        }

    }

    public class Program
    {
        private static readonly TimeSpan DelayTime = TimeSpan.FromSeconds(3);

        private static TimeSpan? ReadConsoleMaxTime(string message)
        {
            Console.WriteLine($"{message} Max Waiting Time (seconds):");

            var input = Console.ReadLine();

            if (int.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out var intResult))
            {
                return TimeSpan.FromSeconds(intResult);
            }

            return null;
        }

        public static async Task Main()
        {
            var service = new SlowRunningService();

            Console.WriteLine($"ETA: {DelayTime.TotalSeconds:N} seconds");

            TimeSpan? maxWaitingTime;
            while (true)
            {
                maxWaitingTime = ReadConsoleMaxTime("Fetch");
                if (maxWaitingTime == null)
                    break;

                using var tokenSource = new CancellationTokenSource(maxWaitingTime.Value);
                var token = tokenSource.Token;
                token.Register(() => Logger.Log($"Fetch: Cancelled token={token.GetHashCode()}"));
                var resultTask = service.Fetch(DelayTime, token);

                try
                {
                    await resultTask;
                    if (resultTask.IsCompletedSuccessfully)
                        Logger.Log($"Fetch: Result={resultTask.Result:N0}");
                    else
                        Logger.Log($"Fetch: Status={resultTask.Status}");
                }
                catch (TaskCanceledException ex)
                {
                    Logger.Log($"Fetch: TaskCanceledException {ex.Message}");
                }
            }

            while (true)
            {
                maxWaitingTime = ReadConsoleMaxTime("FetchLoop");
                if (maxWaitingTime == null)
                    break;

                using var tokenSource = new CancellationTokenSource(maxWaitingTime.Value);
                var token = tokenSource.Token;
                token.Register(() => Logger.Log($"FetchLoop: Cancelled token={token.GetHashCode()}"));
                var resultTask = service.FetchLoop(DelayTime, token);

                try
                {
                    await resultTask;
                    if (resultTask.IsCompletedSuccessfully)
                        Logger.Log($"FetchLoop: Result={resultTask.Result:N0}");
                    else
                        Logger.Log($"FetchLoop: Status={resultTask.Status}");
                }
                catch (TaskCanceledException ex)
                {
                    Logger.Log($"FetchLoop: TaskCanceledException {ex.Message}");
                }
            }

        }

        
    }
}