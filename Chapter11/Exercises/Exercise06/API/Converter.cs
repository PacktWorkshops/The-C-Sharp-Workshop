namespace API
{
    public class Converter
    {
        public static int ToCelsius(ETemperatureUnit @from, double value) => @from switch
        {
            ETemperatureUnit.Fahrenheit => (int)(5 * (value - 32) / 9),
            ETemperatureUnit.Kelvin => (int)value - 273,
            _ => (int)value,
        };

        public static int ToFahrenheit(ETemperatureUnit @from, double value) => @from switch
        {
            ETemperatureUnit.Celsius => (int)(1.8 * value + 32),
            ETemperatureUnit.Kelvin => (int)(1.8 * ToCelsius(@from, value) + 32),
            _ => (int)value
        };

        public static int ToKelvin(ETemperatureUnit @from, double value) => @from switch
        {
            ETemperatureUnit.Celsius => (int)(value + 273),
            ETemperatureUnit.Fahrenheit => ToCelsius(@from, value) + 273,
            _ => (int)value
        };
    }

    public enum ETemperatureUnit
    {
        Celsius,
        Fahrenheit,
        Kelvin
    }
}
