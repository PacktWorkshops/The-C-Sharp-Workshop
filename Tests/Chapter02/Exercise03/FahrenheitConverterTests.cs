using Chapter02.Exercises.Exercise04;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter02.Exercise03
{
    [TestClass]
    public class FahrenheitConverterTests
    {
        private const double Tolerance = 0.001;
            
        [DataTestMethod]
        [DataRow(0.1, -17.72222)]
        [DataRow(1, -17.22222)]
        [DataRow(2, -16.66666)]
        [DataRow(10, -12.22222)]
        [DataRow(100, 37.77777)]
        [DataRow(1000, 537.77777)]
        public void ToC_Returns_Expected(double fahrenheit, double expectedCelsius)
        {
            var converter = new FahrenheitConverter();
            var fahrenheitTemperature = new Temperature(fahrenheit, converter.Unit);
            
            var celsiusTemperature = converter.ToC(fahrenheitTemperature);

            Assert.AreEqual(TemperatureUnit.C, celsiusTemperature.Unit);
            Assert.AreEqual(expectedCelsius, celsiusTemperature.Degrees, Tolerance);
        }

        [DataTestMethod]
        [DataRow(-17.72222, 0.1)]
        [DataRow(-17.22222, 1)]
        [DataRow(-16.66666, 2)]
        [DataRow(-12.22222, 10)]
        [DataRow(37.77777, 100)]
        [DataRow(537.77777, 1000)]
        public void FromC_Returns_Expected(double celsius, double expectedFahrenheit)
        {
            var converter = new FahrenheitConverter();
            var celsiusTemperature = new Temperature(celsius, TemperatureUnit.C);
            
            var fahrenheitTemperature = converter.FromC(celsiusTemperature);

            Assert.AreEqual(converter.Unit, fahrenheitTemperature.Unit);
            Assert.AreEqual(expectedFahrenheit, fahrenheitTemperature.Degrees, Tolerance);
        }
    }
}
