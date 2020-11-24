using System;

namespace Chapter02.Exercises.Exercise03
{
    public class FahrenheitConverter : ITemperatureConverter
    {
        public TemperatureUnit Unit => TemperatureUnit.F;

        public Temperature ToC(double fahrenheit)
        {
            return new Temperature(5.0/9 * (fahrenheit - 32), TemperatureUnit.C);
        }

        public Temperature FromC(double celsius)
        {
            return new Temperature(9.0 / 5 * celsius + 32, Unit);
        }
    }
}