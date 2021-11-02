using System;
using Chapter09.Service.Exercises.Exercise02;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.Chapter09.Exercises.Exercise02
{
    [TestClass]
    public class CurrentTimeControllerTests
    {
        private CurrentTimeController _controller;

        private Mock<ICurrentTimeProvider> _currentTimeProvider;

        [TestInitialize]
        public void SetUp()
        {
            _currentTimeProvider = new Mock<ICurrentTimeProvider>();
            _controller = new CurrentTimeController(_currentTimeProvider.Object);
        }

        public void Get_ReturnsTimeFromProvider()
        {
            const string zoneId = "testZone";
            var expectedDate = new DateTime();
            _currentTimeProvider
                .Setup(ctp => ctp.GetTime(zoneId))
                .Returns(expectedDate);

            var time = _controller.Get(zoneId);

            Assert.IsInstanceOfType(time, typeof(OkObjectResult));
            var timeResult = (OkObjectResult)time;
            Assert.AreEqual(expectedDate, timeResult.Value);
        }
    }
}
