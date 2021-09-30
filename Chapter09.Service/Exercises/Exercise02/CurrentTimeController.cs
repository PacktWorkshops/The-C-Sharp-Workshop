using System;
using Microsoft.AspNetCore.Mvc;

namespace Chapter09.Service.Exercises.Exercise02
{
    [ApiController]
    [Route("[controller]")]
    public class CurrentTimeController : ControllerBase
    {
        private readonly ICurrentTimeProvider _currentTimeProvider;

        public CurrentTimeController(ICurrentTimeProvider currentTimeProvider)
        {
            _currentTimeProvider = currentTimeProvider;
        }

        [HttpGet]
        public IActionResult Get(string timezoneId)
        {
            var time = _currentTimeProvider.GetTime(timezoneId);
            return Ok(time);
        }
    }

    public interface ICurrentTimeProvider
    {
        DateTime GetTime(string timezoneId);
    }

    public class CurrentTimeUtcProvider : ICurrentTimeProvider
    {
        public DateTime GetTime(string timezoneId)
        {
            var timezoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timezoneId);
            var time = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timezoneInfo);

            return time;
        }
    }
}
