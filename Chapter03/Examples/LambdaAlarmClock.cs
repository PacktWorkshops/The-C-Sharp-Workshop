using System;

namespace Chapter03Examples
{
    public class AlarmClock
    {
        public event EventHandler WakeUp = delegate { };
        public event EventHandler<DateTime> Ticked = delegate { };
    }

    public class Program
    {
        public static void Main()
        {
            var clock = new AlarmClock();
            clock.Ticked += (sender, e) =>
            {
                Console.Write($"{e:t}...");
            };
            clock.WakeUp += (sender, e) =>
            {
                Console.WriteLine();
                Console.WriteLine("Wake up");
            };

        }
    }
}

