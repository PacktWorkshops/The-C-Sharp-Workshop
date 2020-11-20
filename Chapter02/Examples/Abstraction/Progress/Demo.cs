using System;

namespace Chapter02.Examples.Abstraction.Progress
{
    public static class Demo
    {
        public static void Run()
        {
            Bad();
        }

        private static void Bad()
        {
            // With bad abstraction, too many details
            // of how to interact with a class are leaked
            var bar = new ProgressBarBad(0, 100);
            var newProgress = 120;
            if (newProgress > bar.Max)
            {
                bar.Current = 100;
            }
            else
            {
                bar.Current = newProgress;
            }

            const double tolerance = 0.0001;
            var isComplete = Math.Abs(bar.Max - bar.Current) > tolerance;
        }

        private static void Good()
        {
            // With bad abstraction, too many details
            // of how to interact with a class are leaked
            var bar = new ProgressBarGood(0, 100);
            bar.Current = 120;
            bool isComplete = bar.IsComplete;
        }
    }
}
