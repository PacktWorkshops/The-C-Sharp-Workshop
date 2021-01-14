using Chapter02.Exercises.Exercise03;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter02.Exercise03
{
    [TestClass]
    public class KelvinConverterTests
    {
        [DataTestMethod]
        [DataRow(0, -273.15)]
        [DataRow(10, -263.15)]
        public void ToC_Returns_Expected(double kelvin, double expectedCelsius)
        {
            var converter = new KelvinConverter();
            var temperature = new Temperature(kelvin, TemperatureUnit.K);
            var expectedTemperature = new Temperature(expectedCelsius, TemperatureUnit.C);

            var celsiusTemperature = converter.ToC(temperature);

            Assert.AreEqual(expectedTemperature, celsiusTemperature);
        }

        [DataTestMethod]
        [DataRow(-273.15, 0)]
        [DataRow(-263.15, 10)]
        public void FromC_Returns_Expected(double celsius, double expectedKelvin)
        {
            var converter = new KelvinConverter();
            var temperature = new Temperature(celsius, TemperatureUnit.C);
            var expectedTemperature = new Temperature(expectedKelvin, TemperatureUnit.K);

            var kelvinTemperature = converter.FromC(temperature);

            Assert.AreEqual(expectedTemperature, kelvinTemperature);
        }
    }
}
