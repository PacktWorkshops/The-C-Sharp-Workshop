using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Chapter10.Tests
{
    [TestFixture]
    public class ExamplesTests
    {

        [Test]
        public void AssertThat_NumberExamples()
        {
            Assert.That(2, Is.LessThan(3));
            Assert.That(5, Is.InRange(4, 6));
            Assert.That(10 + 2, Is.Not.EqualTo(20));
            Assert.That(20.1, Is.EqualTo(20.2).Within(1).Percent);
        }

        [Test]
        public void AssertThat_StringExample()
        {
            Assert.That("C# Workshop", Is.EqualTo("C# WORKSHOP").IgnoreCase);
        }

        [Test]
        public void AssertThat_DateExamples()
        {
            Assert.That(new DateTime(2020, 12, 31), Is.LessThan(new DateTime(2021, 1, 1)));
        }


        [Test]
        public void AssertThat_IsCommonlyUsed()
        {
            const int Height = 10;
            const int Width = 20;
            var area = Height * Width;
            Assert.That(area, Is.Positive);

            var numbers = new List<int> { -1, -3, -7, -9 };
            Assert.That(numbers, Is.Ordered.Descending);
            Assert.That(numbers, Is.All.Negative);

            var dates = new List<DateTime>();
            Assert.That(dates, Is.Empty);

            Assert.That(DateTime.Now.Year, Is.AtLeast(2021));

            const int OpeningBalance = 100;
            const int AmountWithdrawn = 100;
            const int FinalBalance = OpeningBalance - AmountWithdrawn;
            Assert.That(FinalBalance, Is.Zero);

            Assert.That(new ApplicationException(), Is.InstanceOf<Exception>());

            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);
            Assert.That(today, Is.Not.SameAs(tomorrow));
            var days = new[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday };
            Assert.That(days, Is.Not.AnyOf(DayOfWeek.Saturday, DayOfWeek.Sunday));

        }

       

        [Test]
        public void AssertThat_ContainsCommonlyUsed()
        {
            var keys = new[] {ConsoleKey.Spacebar, ConsoleKey.Tab, ConsoleKey.Clear};
            Assert.That(keys, Contains.Item(ConsoleKey.Tab));

            var stringKey = new Dictionary<ConsoleColor, string>
            {
                {ConsoleColor.Green, "Ok"},
                {ConsoleColor.Red, "Error"},
                {ConsoleColor.Yellow, "Warning"}
            };
            Assert.That(stringKey, Contains.Key(ConsoleColor.Green));
            Assert.That(stringKey, Contains.Value("Ok"));
        }

        [Test]
        public void AssertThat_HasSomeGreaterThan()
        {
            var angles = new [] {45,90, 135, 180};
            Assert.That(angles, Has.Some.GreaterThan(90));
        }

        [Test]
        public void AssertThat_DoesDictionary()
        {
            var valuesByCountry = new Dictionary<string, int>
            {
                {"UK", 1000},
                {"Spain", 2000},
                {"France", 3000}
            };
            Assert.That(valuesByCountry, Does.ContainKey("UK"));
            Assert.That(valuesByCountry, Does.ContainValue(3000));
        }
[Test]
public void AssertThat_DoesStringExamples()
{
    Assert.That(".Net Core", Does.StartWith(".Net"));
    Assert.That(".Net Core", Does.EndWith("Core"));
    Assert.That("this is vs code", Does.Contain("VS").IgnoreCase);

    Assert.That("red blue green", Does.StartWith("red").Or.EndWith("green"));
}

[Test]
public void AssertThat_StringListExamples()
{
    var names = new[] { "paul", "craig", "richard", "geoff", "dan" };
    Assert.That(names, Contains.Item("paul"));
    Assert.That(names, Does.Contain("geoff"));
    Assert.That(names, Has.No.Member("jason"));
}
    }
}