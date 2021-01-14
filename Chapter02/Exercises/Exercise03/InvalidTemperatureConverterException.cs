using System;
using Chapter02.Exercises.Exercise03;

namespace Tests.Chapter02.Exercise03
{
    public class InvalidTemperatureConverterException : Exception
    {
        public InvalidTemperatureConverterException(TemperatureUnit unit) : base($"Duplicate converter for {unit}.")
        {
        }

        public InvalidTemperatureConverterException(string message) : base(message)
        {
        }
    }
}