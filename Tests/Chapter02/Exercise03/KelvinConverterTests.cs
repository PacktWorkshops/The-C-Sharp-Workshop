using Chapter02.Exercises.Exercise03;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter02.Exercise03
{
    [TestClass]
    public class KelvinConverterTests
    {
        private const double Tolerance = 0.001;
            
        [DataTestMethod]
        [DataRow(0, -273.15)]
        [DataRow(10, -263.15)]
        public void ToC_Returns_Expected(double kelvin, double expectedCelsius)
        {
            var converter = new KelvinConverter();

            var celsiusTemperature = converter.ToC(kelvin);

            Assert.AreEqual(TemperatureUnit.C, celsiusTemperature.Unit);
            Assert.AreEqual(expectedCelsius, celsiusTemperature.Degrees, Tolerance);
        }

        [DataTestMethod]
        [DataRow(-17.72222, 0.1)]
        [DataRow(-17.22222, 1)]
        public void FromC_Returns_Expected(double celsius, double expectedKelvin)
        {
            var converter = new KelvinConverter();

            var kelvinTemperature = converter.FromC(celsius);

            Assert.AreEqual(converter.Unit, kelvinTemperature.Unit);
            Assert.AreEqual(expectedKelvin, kelvinTemperature.Degrees, Tolerance);
        }
    }
}
