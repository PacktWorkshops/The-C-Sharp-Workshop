using System;
using System.Net.Http;
using Api = Chapter09.Service;
using Activity = Chapter09.Activity01;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter09.NonFunctional.Common
{
    [TestClass]
    public class Chapter09ApiFixture
    {
        public static HttpClient ClientApi { get; set; }
        public static HttpClient ClientActivity { get; set; }

        [AssemblyInitialize]
        public static void SetupOnce(TestContext context)
        {
            var factoryApi = new WebApplicationFactoryTesting<Api.Startup>();
            ClientApi = factoryApi.CreateClient();
            ClientApi.DefaultRequestHeaders.Add("Authorization", FakeTokenWithAccessAsUserClaim);
            ClientApi.BaseAddress = new Uri($"{ClientApi.BaseAddress.AbsoluteUri}WeatherForecast/");
            
            var factoryActivity = new WebApplicationFactoryTesting<Activity.Startup>();
            ClientActivity = factoryActivity.CreateClient();
            ClientActivity.BaseAddress = new Uri($"{ClientActivity.BaseAddress.AbsoluteUri}File/");
            ClientActivity.DefaultRequestHeaders.Add("Authorization", FakeTokenWithAccessAsUserClaim);
        }

        [AssemblyCleanup]
        public static void TeardownOnce()
        {
            ClientApi.Dispose();
            ClientActivity.Dispose();
        }

        private const string FakeTokenWithAccessAsUserClaim = "Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJEaW5vQ2hpZXNhLmdpdGh1Yi5pbyIsInN1YiI6Im1pbmciLCJhdWQiOiJtYXhpbmUiLCJpYXQiOjE2MzU4ODkzMzksImV4cCI6MTYzNTg4OTkzOSwic2NwIjoiYWNjZXNzX2FzX3VzZXIifQ.HKHARx43Gu19GM_vxWrF8crw-jin2Tt8DRgeiD9kAeldN2Bl_wqzJv0wq7M0Or5JJEGZgUO1ht3d5PObWTg4COaMf3GDd6azAq37tb8Q7u4dstah8VGbnASzf0-t_f1ynexuZP2JgOz2tq2AY1etsHtyfD4bgZ6VJoXa_eK1U4VkoWHwCLTED1L1L75Qh3GUaoluRyBkbCFDvRnVF8lc3r5zdDyjmxOBHTsrQsHnFRNuqb0SXmwAETv6PbZHrt02Vf0GkaSOok5TO4Ics6F-lhy--lNUGmS8Q7LwOB_Fvh0HipjCDqMrtev9Ajv4q9DzhpgJokOpozN-9je3aZrz5Q";
    }
}