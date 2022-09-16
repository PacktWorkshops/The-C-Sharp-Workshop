using System;
using System.Diagnostics;
using System.Threading;
using Chapter03.Exercise05;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter03
{
    [TestClass]
    public class Exercise05Tests
    {
        private readonly ManualResetEventSlim _waiter = new ManualResetEventSlim();
        
        [TestMethod]
        public void AlarmClock_WakeTimeSet_FiresWakeTime()
        {
            var hasSignalled = false;
            var clock = new AlarmClock();

            clock.Ticked += ClockTicked;
            clock.WakeUp += ClockOnWakeUp;

            clock.ClockTime = DateTime.Now;
            clock.AlarmTime = DateTime.Now.AddMinutes(2);
            Debug.WriteLine($"AlarmTime set to {clock.AlarmTime}");
            clock.Start();

            hasSignalled = _waiter.Wait(TimeSpan.FromMinutes(5));

            Assert.IsTrue(hasSignalled);
        }

        private void ClockOnWakeUp(object sender, EventArgs e)
        {
            Debug.WriteLine("Time to wake up");
            _waiter.Set();
        }

        private static void ClockTicked(object sender, DateTime e)
        {
            Debug.WriteLine($"ClockTicked : sender={sender} e={e}");
        }
    }
}
