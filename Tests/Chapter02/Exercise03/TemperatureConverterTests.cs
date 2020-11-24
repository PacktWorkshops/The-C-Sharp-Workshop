using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chapter02.Activities.Activity02;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter02.Exercise03
{
    [TestClass]
    public class TemperatureConverterTests
    {
        [TestMethod]
        public void Convert_Given_NoConverters_Throws()
        {
            var converter = new TemperatureConverter();
            var temparature = new Temperature(1, TemperatureUnit.C);

            void Convert() => converter.Convert(Temperature, TemperatureUnit.F);

            Assert.ThrowsException<InvalidTemperatureConversionException>(Convert);
        }

        [TestMethod]
        public void Test()
        {
            var converter = new TemperatureConverter();
            var temparature = new Temperature(1, TemperatureUnit.C);

            converter.Convert(Temperature, TemperatureUnit.C)
        }
    }
}
