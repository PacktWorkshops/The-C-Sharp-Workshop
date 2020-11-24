using System;

namespace Chapter02.Exercises.Exercise03
{
    public class InvalidTemperatureConversionException : Exception
    {
        public InvalidTemperatureConversionException(TemperatureUnit unitTo)
            : base($"No supported conversion to {unitTo}") { }
    }
}