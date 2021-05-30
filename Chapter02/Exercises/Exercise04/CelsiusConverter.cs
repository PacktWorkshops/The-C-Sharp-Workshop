namespace Chapter02.Exercises.Exercise04
{
    public class CelsiusConverter : ITemperatureConverter
    {
        public TemperatureUnit Unit => TemperatureUnit.C;

        public Temperature ToC(Temperature temperature)
        {
            return temperature;
        }

        public Temperature FromC(Temperature temperature)
        {
            return temperature;
        }
    }
}