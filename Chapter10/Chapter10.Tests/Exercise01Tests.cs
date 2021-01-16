using System;
using NUnit.Framework;

namespace Chapter10.Tests
{
    [TestFixture]
    public class Exercise01Tests
    {
        [Test]
        public void AssertThat_TwoNumbers_ReturnProduct()
        {
            Assert.That(10 * 10, Is.EqualTo(100));
        }
       
    }
}