using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Chapter09.Service.Exercises.Exercise01
{
    [ApiController]
    [Route("[controller]")]
    public class TimeController : ControllerBase
    {
        [HttpGet("current")]
        public IActionResult GetCurrentTime()
        {
            return Ok(DateTime.Now.ToString("o"));
        }
    }
}
