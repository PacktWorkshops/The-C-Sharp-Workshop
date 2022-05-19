using System;
using System.Diagnostics;

namespace Chapter06.Examples.PerformanceTraps
{
    public static class Demo
    {
        public static void Run()
        {
            // For benchmarks to be more accurate, make sure you run the seeding before anything
            // And then restart the application
            // Lazy loading is a prime example of being impacted by this inverting the intended results.
            DataSeeding.SeedDataNotSeededBefore();
            // Slow-Faster example pairs
            // The title does not illustrate which you should pick
            // It rather illustrates when it becomes a problem.
            CompareExecTimes(EnumerableVsQueryable.Slow, EnumerableVsQueryable.Fast, "IEnumerable over IQueryable");
            CompareExecTimes(MethodChoice.Slow, MethodChoice.Fast, "equals over ==");
            CompareExecTimes(Loading.Lazy, Loading.Eager, "Lazy over Eager loading");
            CompareExecTimes(LightweightEf.Default, LightweightEf.AsNoTracking, "AsNoTracking for many readonly entities");
            CompareExecTimes(MultipleAddsOrRemoves.Slow, MultipleAddsOrRemoves.Fast, "Add over AddRange");
        }

        private static void CompareExecTimes(Action slow, Action fast, string scenarioLabel)
        {
            var sw = new Stopwatch();
            sw.Start();
            slow();
            sw.Stop();
            var slowTime = sw.ElapsedMilliseconds;

            sw.Restart();
            fast();
            sw.Stop();
            var fastTime = sw.ElapsedMilliseconds;

            Console.WriteLine("{0,-40} Scenario1:{1,-7} Scenario2: {2}", 
                scenarioLabel.ToUpper(),
                slowTime+"ms,", fastTime+"ms");
        }
    }
}
