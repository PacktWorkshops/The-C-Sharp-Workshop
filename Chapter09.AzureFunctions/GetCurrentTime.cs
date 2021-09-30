using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Web;

namespace Pact.Function
{
    public static class GetCurrentTime
    {
        [Function("GetCurrentTime")]
        public static HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData request,
            FunctionContext executionContext)
        {
            var timezoneId = HttpUtility.ParseQueryString(request.Url.Query).Get("timezoneId");
            var timezoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timezoneId);
            var time = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timezoneInfo);

            var response = request.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            response.WriteString(time.ToString());

            return response;
        }
    }
}
