using NUnit.Framework;

namespace Chapter10.Tests
{
    [TestFixture]
    public class BasicTests
    {
        [Test]
        public void AssertThat_TwoNumbers_ReturnSum()
        {
            Assert.That(10 * 10, Is.EqualTo(100));
        }

        [Test]
         public void AssertThat_NumberExamples()
        {
            Assert.That(2, Is.LessThan(3));
            Assert.That(5, Is.InRange(4, 6));
            Assert.That(10 + 2, Is.Not.EqualTo(20));
            Assert.That(20.1, Is.EqualTo(20.2).Within(1).Percent);
        }

        [Test]
        public void AssertThat_StringExamples()
        {
            Assert.That("C# Workshop", Is.EqualTo("C# WORKSHOP").IgnoreCase);
            Assert.That(".Net Core", Does.StartWith(".Net"));

            var names = new [] { "paul", "craig", "richard", "geoff"};
            Assert.That(names, Contains.Item("paul"));
            Assert.That(names, Does.Contain("geoff"));
            Assert.That(names, Has.No.Member("jason"));
        }
    }
}