using System;
using Tests.Chapter02.Exercise03;

namespace Chapter02.Exercises.Exercise03
{
    public class ComposableTemperatureConverter
    {
        private readonly ITemperatureConverter[] _converters;

        public ComposableTemperatureConverter(ITemperatureConverter[] converters)
        {
            RequireNoDuplicate(converters);
            _converters = converters;
        }

        public Temperature Convert(Temperature temperatureFrom, TemperatureUnit unitTo)
        {
            if (temperatureFrom.Unit == unitTo)
            {
                return temperatureFrom;
            }

            if (temperatureFrom.Unit == TemperatureUnit.C)
            {
                return CelsiusToOther(temperatureFrom, unitTo);
            }

            var celsius = ToCelsius(temperatureFrom);
            if (unitTo == TemperatureUnit.C)
            {
                return celsius;
            }

            // In case temperature is not standard
            // We need to first make it standard
            // And only then convert to other.
            return CelsiusToOther(celsius, unitTo);
        }

        private Temperature ToCelsius(Temperature temperatureFrom)
        {
            var converterFrom = FindConverter(temperatureFrom.Unit);
            return converterFrom.ToC(temperatureFrom.Degrees);
        }

        private Temperature CelsiusToOther(Temperature celsius, TemperatureUnit unitTo)
        {
            var converterTo = FindConverter(unitTo);
            return converterTo.FromC(celsius.Degrees);
        }

        private static void RequireNoDuplicate(ITemperatureConverter[] converters)
        {
            for (var index1 = 0; index1 < converters.Length - 1; index1++)
            {
                var first = converters[index1];
                for (int index2 = index1 + 1; index2 < converters.Length; index2++)
                {
                    var second = converters[index2];
                    if (first.Unit == second.Unit)
                    {
                        throw new DuplicateTemperatureConverterException(first.Unit);
                    }
                }
            }
        }

        private ITemperatureConverter FindConverter(TemperatureUnit unit)
        {
            foreach (var converter in _converters)
            {
                if (converter.Unit == unit)
                {
                    return converter;
                }
            }

            throw new InvalidTemperatureConversionException(unit);
        }
    }
}
