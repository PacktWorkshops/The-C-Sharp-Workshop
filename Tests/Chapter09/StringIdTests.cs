using Chapter09.Service.Static;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Chapter09
{
    [TestClass]
    public class StringIdTests
    {
        [TestMethod]
        public void RandomIdsAreUnique()
        {
            HashSet<string> test = new HashSet<string>();

            const int iterations = 1_000_000;
            for (int i = 0; i < iterations; i++) test.Add(StringId.NewId(10));

            // if the generated Ids are unique enough, then the hash set count will equal the iteration count
            Assert.IsTrue(test.Count == iterations);
            Assert.IsTrue(test.All(id => id.Length == 10));

            // We're assuming that a million 10-character Ids should be unique.
            // We'd likely have to tune this assumption for different Id lengths and number of iterations
        }
    }
}
