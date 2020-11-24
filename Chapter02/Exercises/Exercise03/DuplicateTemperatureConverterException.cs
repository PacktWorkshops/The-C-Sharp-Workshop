using System;
using Chapter02.Exercises.Exercise03;

namespace Tests.Chapter02.Exercise03
{
    public class DuplicateTemperatureConverterException : Exception
    {
        public DuplicateTemperatureConverterException(TemperatureUnit unit) : base($"Duplicate converter for {unit}.")
        {
        }
    }
}