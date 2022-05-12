using System;

namespace Chapter03.Exercise05
{
    public class AlarmClock
    {
        public event EventHandler WakeUp = delegate { };
        public event EventHandler<DateTime> Ticked = delegate { };

        protected void OnWakeUp()
        {
            WakeUp.Invoke(this, EventArgs.Empty);
        }

        public DateTime AlarmTime { get; set; }

        public DateTime ClockTime { get; set; }

        public void Start()
        {
            // Run for 24 hours
            const int MinutesInADay = 60 * 24;
            for (var i = 0; i < MinutesInADay; i++)
            {
                ClockTime = ClockTime.AddMinutes(1);
                Ticked.Invoke(this, ClockTime);

                var timeRemaining = ClockTime
                   .Subtract(AlarmTime)
                   .TotalMinutes;
                   
                if (IsTimeToWakeUp(timeRemaining))
                {
                    OnWakeUp();
                    break;
                }
            }

            static bool IsTimeToWakeUp(double timeRemaining) 
                => timeRemaining is (>= -1.0 and <= 1.0);
        }

    }

    public static class Program
    {
        public static void Main()
        {
            var clock = new AlarmClock();
            clock.Ticked += ClockTicked;
            clock.WakeUp += ClockWakeUp;
            clock.ClockTime = DateTime.Now;
            clock.AlarmTime = DateTime.Now.AddMinutes(120);

            Console.WriteLine($"ClockTime={clock.ClockTime:t}");
            Console.WriteLine($"AlarmTime={clock.AlarmTime:t}");
            clock.Start();

            Console.WriteLine("Press ENTER");
            Console.ReadLine();

            static void ClockWakeUp(object sender, EventArgs e)
            {
                Console.WriteLine();
                Console.WriteLine("Wake up");
            }

            static void ClockTicked(object sender, DateTime e) 
                => Console.Write($"{e:t}...");
        }

        
    }
}