using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chapter09.Service.Exercises.Exercise02;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter09.Exercises.Exercise02
{
    [TestClass]
    public class CurrentTimeProviderTests
    {
        [TestMethod]
        public void GetTime_ReturnsTimeInUtcFormat()
        {
            var expectedHour = DateTime.UtcNow.Hour + 1;
            var timeProvider = new CurrentTimeUtcProvider();

            var time = timeProvider.GetTime("Central European Standard Time");

            Assert.AreEqual(expectedHour, time.Hour);
        }
    }
}
