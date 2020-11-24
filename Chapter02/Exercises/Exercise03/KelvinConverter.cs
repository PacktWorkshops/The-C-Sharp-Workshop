using System;

namespace Chapter02.Exercises.Exercise03
{
    public class KelvinConverter : ITemperatureConverter
    {
        public const double AbsoluteZero = -273.15;

        public TemperatureUnit Unit => TemperatureUnit.K;

        public Temperature ToC(double kelvin)
        {
            return new Temperature(kelvin - AbsoluteZero, TemperatureUnit.C);
        }

        public Temperature FromC(double celsius)
        {
            return new Temperature(celsius + AbsoluteZero, Unit);
        }
    }
}