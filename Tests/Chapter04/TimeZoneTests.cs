using Chapter04;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Chapter04
{
    [TestClass]
    public class TimeZoneTests
    {
        [TestMethod]
        public void TimeZonesByCode()
        {
            // There are 139 standard time zones.
            // we just want to be sure that the ByCode static property gives us all of them.
            // If there's no exception, we know the codes are unique
            var codes = TimeZones.ByCode;
            Assert.IsTrue(codes.Count == 139);
        }

        [TestMethod]
        public void EasterDaylightToIndiaStandardOffset()
        {
            // India Standard is +10.5 hours from Eastern Daylight
            var offset = TimeZones.ByCode["ist.3"].BaseUtcOffset - TimeZones.ByCode["est.1"].BaseUtcOffset;
            Assert.IsTrue(offset.Equals(TimeSpan.FromHours(10) + TimeSpan.FromMinutes(30)));
        }
    }
}
