using System;

namespace Chapter02.Exercises.Exercise03
{
    public class FahrenheitConverter : ITemperatureConverter
    {
        public TemperatureUnit Unit => TemperatureUnit.F;

        public Temperature ToC(Temperature temperature)
        {
            return new(5.0/9 * (temperature.Degrees - 32), TemperatureUnit.C);
        }

        public Temperature FromC(Temperature temperature)
        {
            return new(9.0 / 5 * temperature.Degrees + 32, Unit);
        }
    }
}