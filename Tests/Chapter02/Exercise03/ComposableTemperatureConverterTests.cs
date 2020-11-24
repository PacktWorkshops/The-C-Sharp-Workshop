using System.Collections.Generic;
using Chapter02.Exercises.Exercise03;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.Chapter02.Exercise03
{
    [TestClass]
    public class ComposableTemperatureConverterTests
    {
        [DataTestMethod]
        [DynamicData(nameof(ConvertersWithKelvin))]
        public void New_When_UniqueConverters_DoesNotThrow(ITemperatureConverter[] converters)
        {
            new ComposableTemperatureConverter(converters);
        }

        [TestMethod]
        public void New_When_DuplicateConverters_Throws_DuplicateTemperatureConverterException()
        {
            ITemperatureConverter[] converters = {new FahrenheitConverter(), new FahrenheitConverter()};
            
            void New() => new ComposableTemperatureConverter(converters);

            Assert.ThrowsException<DuplicateTemperatureConverterException>(New);
        }

        [TestMethod]
        public void Convert_When_SameUnit_Returns_TheSameTemperature()
        {
            var converters = new ITemperatureConverter[] {new FahrenheitConverter()};
            var converter = new ComposableTemperatureConverter(converters);
            var temparature = new Temperature(1, TemperatureUnit.C);

            var convertedTemperature = converter.Convert(temparature, TemperatureUnit.C);

            Assert.AreSame(temparature, convertedTemperature);
        }

        [TestMethod]
        public void Convert_ToC_WhenK_And_ConverterForKExists_CallsKConverterToC()
        {
            const TemperatureUnit unit = TemperatureUnit.K;

            var kelvinConverter = new Mock<ITemperatureConverter>();
            kelvinConverter
                .SetupGet(c => c.Unit)
                .Returns(unit);

            var converters = new[] {kelvinConverter.Object};
            
            var converter = new ComposableTemperatureConverter(converters);
            var temperature = new Temperature(1, unit);

            converter.Convert(temperature, TemperatureUnit.C);

            kelvinConverter.Verify(c => c.ToC(temperature.Degrees));
        }

        [TestMethod]
        public void Convert_ToNotC_WhenC_And_ConverterForKExists_CallsKConverterFromC()
        {
            const TemperatureUnit unit = TemperatureUnit.K;

            var kelvinConverter = new Mock<ITemperatureConverter>();
            kelvinConverter
                .SetupGet(c => c.Unit)
                .Returns(unit);

            var converters = new[] { kelvinConverter.Object };

            var converter = new ComposableTemperatureConverter(converters);
            var temperature = new Temperature(1, TemperatureUnit.C);

            converter.Convert(temperature, unit);

            kelvinConverter.Verify(c => c.FromC(temperature.Degrees));
        }

        [TestMethod]
        public void Convert_ToK_WhenF_And_ConverterForKAndFExists_Calls_FConverterToC_Then_KConverterFromC()
        {
            var temperatureF = new Temperature(1, TemperatureUnit.F);
            var temperatureC = new Temperature(2, TemperatureUnit.C);

            var fahrenheitConverterConverter = new Mock<ITemperatureConverter>();
            fahrenheitConverterConverter
                .SetupGet(c => c.Unit)
                .Returns(TemperatureUnit.F);

            fahrenheitConverterConverter
                .Setup(c => c.ToC(temperatureF.Degrees))
                .Returns(temperatureC);

            var kelvinConverter = new Mock<ITemperatureConverter>();
            kelvinConverter
                .SetupGet(c => c.Unit)
                .Returns(TemperatureUnit.K);

            var converters = new[] { kelvinConverter.Object, fahrenheitConverterConverter.Object };

            var converter = new ComposableTemperatureConverter(converters);
            

            converter.Convert(temperatureF, TemperatureUnit.K);

            fahrenheitConverterConverter.Verify(c => c.ToC(temperatureF.Degrees));
            kelvinConverter.Verify(c => c.FromC(temperatureC.Degrees));
        }

        public static IEnumerable<object[]> ConvertersWithKelvin
        {
            get
            {
                yield return new object[]{new ITemperatureConverter[]{new KelvinConverter()}};
                yield return new object[]{new ITemperatureConverter[]{new FahrenheitConverter(), new KelvinConverter()}};
            }
        }
    }
}
