using Xunit;
using API;

namespace API.Tests
{
    public class ConverterTests
    {
        [Theory]
        [InlineData(1, -17)]
        [InlineData(50, 10)]
        [InlineData(95, 35)]
        [InlineData(73, 22)]
        public void Should_ReturnProperlyConverted_When_Converting_FromFahrenheit_ToCelsius(double from, double result)
        {
            Assert.Equal(result, Converter.ToCelsius(ETemperatureUnit.Fahrenheit, from));
        }

        [Theory]
        [InlineData(273, 0)]
        [InlineData(300, 27)]
        [InlineData(268, -5)]
        public void Should_ReturnProperlyConverted_When_Converting_FromKelvin_ToCelsius(double from, double result)
        {
            Assert.Equal(result, Converter.ToCelsius(ETemperatureUnit.Kelvin, from));
        }

        [Theory]
        [InlineData(15, 59)]
        [InlineData(-27, -16)]
        [InlineData(42, 107)]
        public void Should_ReturnProperlyConverted_When_Converting_FromCelsius_ToFahrenheit(double from, double result)
        {
            Assert.Equal(result, Converter.ToFahrenheit(ETemperatureUnit.Celsius, from));
        }

        [Theory]
        [InlineData(288, 59)]
        [InlineData(246, -16)]
        [InlineData(315, 107)]
        public void Should_ReturnProperlyConverted_When_Converting_FromKelvin_ToFahrenheit(double from, double result)
        {
            Assert.Equal(result, Converter.ToFahrenheit(ETemperatureUnit.Kelvin, from));
        }

        [Theory]
        [InlineData(15, 288)]
        [InlineData(27, 300)]
        [InlineData(100, 373)]
        public void Should_ReturnProperlyConverted_When_Converting_FromCelsius_ToKelvin(double from, double result)
        {
            Assert.Equal(result, Converter.ToKelvin(ETemperatureUnit.Celsius, from));
        }

        [Theory]
        [InlineData(1, 255)]
        [InlineData(50, 283)]
        [InlineData(95, 308)]
        [InlineData(73, 295)]
        public void Should_ReturnProperlyConverted_When_Converting_FromFahrenheit_ToKelvin(double from, double result)
        {
            Assert.Equal(result, Converter.ToKelvin(ETemperatureUnit.Fahrenheit, from));
        }
    }
}