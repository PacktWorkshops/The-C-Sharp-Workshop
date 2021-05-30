namespace Chapter02.Exercises.Exercise04
{
    public class ComposableTemperatureConverter
    {
        private readonly ITemperatureConverter[] _converters;

        public ComposableTemperatureConverter(ITemperatureConverter[] converters)
        {
            RequireNotEmpty(converters);
            RequireNoDuplicate(converters);
            _converters = converters;
        }

        public Temperature Convert(Temperature temperatureFrom, TemperatureUnit unitTo)
        {
            var celsius = ToCelsius(temperatureFrom);
            return CelsiusToOther(celsius, unitTo);
        }

        private Temperature ToCelsius(Temperature temperatureFrom)
        {
            var converterFrom = FindConverter(temperatureFrom.Unit);
            return converterFrom.ToC(temperatureFrom);
        }

        private Temperature CelsiusToOther(Temperature celsius, TemperatureUnit unitTo)
        {
            var converterTo = FindConverter(unitTo);
            return converterTo.FromC(celsius);
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

        private static void RequireNotEmpty(ITemperatureConverter[] converters)
        {
            if (converters?.Length > 0 == false)
            {
                throw new InvalidTemperatureConverterException("At least one temperature conversion must be supported");
            }
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
                        throw new InvalidTemperatureConverterException(first.Unit);
                    }
                }
            }
        }
    }
}
