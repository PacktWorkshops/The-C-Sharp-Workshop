using System;

namespace Chapter02.Activities.Activity02
{
    public class InvalidTemperatureConversionException : Exception
    {
        public InvalidTemperatureConversionException(TemperatureUnit unitTo)
            : base($"No supported conversion to {unitTo}") { }
    }
}