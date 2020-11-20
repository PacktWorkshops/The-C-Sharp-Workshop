namespace Chapter02.Examples.Abstraction.Progress
{
    public class ProgressBarBad
    {
        public float Current { get; set; }
        public float Max { get; }

        public ProgressBarBad(float current, float max)
        {
            Current = current;
            Max = max;
        }
    }
}
