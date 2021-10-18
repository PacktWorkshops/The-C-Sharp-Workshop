namespace Tests.Chapter09.Exercises.Exercise02
{
    public class CurrentTimeControllerTests
    {
    //    private readonly ICurrentTimeProvider _currentTimeProvider;

    //    public CurrentTimeController(ICurrentTimeProvider currentTimeProvider)
    //    {
    //        _currentTimeProvider = currentTimeProvider;
    //    }

    //    [HttpGet]
    //    public IActionResult Get(string timezoneId)
    //    {
    //        var time = _currentTimeProvider.GetTime(timezoneId);
    //        return Ok(time);
    //    }
    //}

    //public interface ICurrentTimeProvider
    //{
    //    DateTime GetTime(string timezoneId);
    //}

    //public class CurrentTimeUtcProvider : ICurrentTimeProvider
    //{
    //    public DateTime GetTime(string timezoneId)
    //    {
    //        var timezoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timezoneId);
    //        var time = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timezoneInfo);

    //        return time;
    //    }
    }
}
