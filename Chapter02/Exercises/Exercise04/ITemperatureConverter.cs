namespace Chapter02.Exercises.Exercise04
{
    public interface ITemperatureConverter
    {
        public TemperatureUnit Unit { get; }
        public Temperature ToC(Temperature temperature);
        public Temperature FromC(Temperature temperature);
    }
}