using System.Collections.Generic;
using Chapter02.Exercises.Exercise04;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.Chapter02.Exercise04
{
    [TestClass]
    public class ComposableTemperatureConverterTests
    {
        [DataTestMethod]
        [DynamicData(nameof(InvalidConverters))]
        public void New_When_NullOrEmptyConverters_Throws_InvalidTemperatureConversionException(ITemperatureConverter[] converters)
        {
            void New() => new ComposableTemperatureConverter(converters);

            Assert.ThrowsException<InvalidTemperatureConverterException>(New);
        }

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

            Assert.ThrowsException<InvalidTemperatureConverterException>(New);
        }

        [TestMethod]
        public void Convert_When_SameUnit_Returns_TheSameTemperature()
        {
            var converters = new ITemperatureConverter[] {new FahrenheitConverter(), new CelsiusConverter()};
            var converter = new ComposableTemperatureConverter(converters);
            var temperature = new Temperature(1, TemperatureUnit.C);

            var convertedTemperature = converter.Convert(temperature, TemperatureUnit.C);

            Assert.AreSame(temperature, convertedTemperature);
        }

        [TestMethod]
        public void Convert_ToC_WhenK_And_ConverterForKExists_CallsKConverterToC()
        {
            var kelvinConverter = new Mock<ITemperatureConverter>();
            kelvinConverter
                .SetupGet(c => c.Unit)
                .Returns(TemperatureUnit.K);

            var converters = new[] {kelvinConverter.Object, new CelsiusConverter()};
            
            var converter = new ComposableTemperatureConverter(converters);
            var temperature = new Temperature(1, TemperatureUnit.K);

            converter.Convert(temperature, TemperatureUnit.C);

            kelvinConverter.Verify(c => c.ToC(temperature));
        }

        [TestMethod]
        public void Convert_ToNotC_WhenC_And_ConverterForKExists_CallsKConverterFromC()
        {
            const TemperatureUnit unit = TemperatureUnit.K;

            var kelvinConverter = new Mock<ITemperatureConverter>();
            kelvinConverter
                .SetupGet(c => c.Unit)
                .Returns(unit);

            var converters = new[] { kelvinConverter.Object, new CelsiusConverter() };

            var converter = new ComposableTemperatureConverter(converters);
            var temperature = new Temperature(1, TemperatureUnit.C);

            converter.Convert(temperature, unit);

            kelvinConverter.Verify(c => c.FromC(temperature));
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
                .Setup(c => c.ToC(temperatureF))
                .Returns(temperatureC);

            var kelvinConverter = new Mock<ITemperatureConverter>();
            kelvinConverter
                .SetupGet(c => c.Unit)
                .Returns(TemperatureUnit.K);

            var converters = new[] { kelvinConverter.Object, fahrenheitConverterConverter.Object };

            var converter = new ComposableTemperatureConverter(converters);
            

            converter.Convert(temperatureF, TemperatureUnit.K);

            fahrenheitConverterConverter.Verify(c => c.ToC(temperatureF));
            kelvinConverter.Verify(c => c.FromC(temperatureC));
        }

        public static IEnumerable<object[]> ConvertersWithKelvin
        {
            get
            {
                yield return new object[]{new ITemperatureConverter[]{new KelvinConverter()}};
                yield return new object[]{new ITemperatureConverter[]{new FahrenheitConverter(), new KelvinConverter()}};
            }
        }

        public static IEnumerable<object[]> InvalidConverters
        {
            get
            {
                yield return new object[] { new ITemperatureConverter[] {} };
                yield return new object[] { null };
            }
        }
    }
}
