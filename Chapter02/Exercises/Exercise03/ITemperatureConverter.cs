namespace Chapter02.Exercises.Exercise03
{
    public interface ITemperatureConverter
    {
        public TemperatureUnit Unit { get; }
        public Temperature ToC(double converterUnitDegrees);
        public Temperature FromC(double celsius);
    }
}