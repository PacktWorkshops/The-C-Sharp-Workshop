using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chapter3;

namespace Chapter3UnitTest
{

    [TestClass]
    public class Exercise06Tests
    {
        [TestMethod]
        public void AlarmClock_WakeTimeSet_FiresWakeTime()
        {
            var hasSignalled = false;
            var waiter = new ManualResetEventSlim();
            using (waiter)
            {
                using var clock = new AlarmClock();

                clock.Ticked += ClockTicked;
                clock.Ticked += (sender, e) => // lambda 
                {
                    Debug.WriteLine($"LambdaTicked: sender={sender} e.value={e.Value}");
                };

                clock.WakeUp += (sender, e) =>
                {
                    Debug.WriteLine($"Time to wake up: time={DateTime.Now.TimeOfDay}");
                    waiter.Set();
                };

                clock.WakeTime = DateTime.Now.AddMinutes(2).TimeOfDay;
                Debug.WriteLine($"WakeTime set to {clock.WakeTime}");
                clock.Start();

                hasSignalled = waiter.Wait(TimeSpan.FromMinutes(5));
            }

            Assert.IsTrue(hasSignalled);
        }

        private static void ClockTicked(object? sender, EventArgs<TimeSpan> e)
        {
            Debug.WriteLine($"ClockTicked : sender={sender} e.value={e.Value}");
        }
    }
}
