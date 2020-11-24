using System;

namespace Chapter02.Examples.Abstraction.Progress
{
    public class ProgressBarGood
    {
        private const float Tolerance = 0.001f;

        private float _current;
        public float Current
        {
            get => _current;
            set
            {
                if (value >= Max)
                {
                    _current = Max;
                }
                else if (value < 0)
                {
                    _current = 0;
                }
                else
                {
                    _current = value;
                }
            }
        }

        public float Max { get; }

        public bool IsComplete => Math.Abs(Max - _current) > Tolerance;

        public ProgressBarGood(float current, float max)
        {
            Current = current;
            Max = max;
        }
    }
}
