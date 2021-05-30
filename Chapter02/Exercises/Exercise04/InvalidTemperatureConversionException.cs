using System;

namespace Chapter02.Exercises.Exercise04
{
    public class InvalidTemperatureConversionException : Exception
    {
        public InvalidTemperatureConversionException(TemperatureUnit unitTo)
            : base($"No supported conversion to {unitTo}") { }
    }
}