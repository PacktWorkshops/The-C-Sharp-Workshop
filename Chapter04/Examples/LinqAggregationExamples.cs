using System;
using System.Diagnostics;
using System.Linq;
namespace Chapter04.Examples
{
    class LinqAggregationExamples
    {
        public static void Main()
        {
            var processes = Process.GetProcesses().ToList();

            var allProcesses = processes.Count;
            var smallProcesses = processes.Count(proc => proc.PrivateMemorySize64 < 1_000_000);
            var average = processes.Average(p => p.PrivateMemorySize64);
            var max = processes.Max(p => p.PrivateMemorySize64);
            var min = processes.Min(p => p.PrivateMemorySize64);
            var sum = processes.Sum(p => p.PrivateMemorySize64);

            Console.WriteLine("Process Memory Details");
            Console.WriteLine($"  All Count: {allProcesses}");
            Console.WriteLine($"Small Count: {smallProcesses}");
            Console.WriteLine($"    Average: {FormatBytes(average)}");
            Console.WriteLine($"    Maximum: {FormatBytes(max)}");
            Console.WriteLine($"    Minimum: {FormatBytes(min)}");
            Console.WriteLine($"      Total: {FormatBytes(sum)}");
        }

        private static string FormatBytes(double bytes)
        {
            return $"{bytes / Math.Pow(1024, 2):N2} MB";
        }
    }
}
