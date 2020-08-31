using System;
using System.Threading;

namespace Chapter3
{
    public class EventArgs<T> : EventArgs
    {
        public EventArgs(T value)
        {
            Value = value;
        }

        public T Value { get; }
    }

    public class AlarmClock : IDisposable
    {
        public event EventHandler<EventArgs<TimeSpan>> Ticked = delegate { };
        public event EventHandler WakeUp;

        protected void OnTicked(EventArgs<TimeSpan> e)
        {
            Ticked(this, e);
        }

        protected void OnWakeUp()
        {
            var evt = WakeUp;
            evt?.Invoke(this, EventArgs.Empty);
        }

        public TimeSpan? WakeTime { get; set; }

        private Timer _timer;

        public void Start()
        {
            var dueTime = TimeSpan.Zero;
            var frequency = TimeSpan.FromMinutes(1);

            if (_timer == null)
            {
                _timer = new Timer(state => CheckAlarmTime(), null,
                    dueTime, frequency);
            }
            else
            {
                _timer.Change(dueTime, frequency);
            }
        }

        private void CheckAlarmTime()
        {
            var currentTime = DateTime.Now.TimeOfDay;

            OnTicked(new EventArgs<TimeSpan>(currentTime));

            var wakeTime = WakeTime;
            if (wakeTime == null)
                return;

            if (currentTime > wakeTime)
            {
                OnWakeUp();
            }
        }

        public void Stop()
        {
            _timer?.Change(TimeSpan.Zero, Timeout.InfiniteTimeSpan);
        }

        public void Dispose()
        {
            if (_timer != null)
            {
                _timer.Dispose();
                _timer = null;
            }
        }
    }
}
