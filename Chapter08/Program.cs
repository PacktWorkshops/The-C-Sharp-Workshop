using RestSharp;
using RestSharp.Serializers.SystemTextJson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exercise01 = Chapter08.Exercises.Exercise01;

namespace Chapter08
{
    class Program
    {
        public static string GitHubPersonAccessToken { get; } = Environment.GetEnvironmentVariable("GitHubPersonalAccess", EnvironmentVariableTarget.User);
        public static string BlobStorageKey { get; } = Environment.GetEnvironmentVariable("BlobStorageKey", EnvironmentVariableTarget.User);

        static async Task Main(string[] args)
        {
            //await Examples.GitOctokit.Demo.Run();
            //await Examples.GitHttp.Demo.Run();
            //await Examples.RESTSharp.Demo.Run();
            //await Examples.REfit.Demo.Run();

            //await Activities.Activity01.Demo.Run();
            //await Activities.Activity02.Demo.Run();
            //await Activities.Activity03.Demo.Run();

            //Exercise01.Demo.Run();
            //await Exercises.Exercise02.Demo.Run();
            //await Exercises.Exercise03.Demo.Run();
            //await Exercises.Exercise04.Demo.Run();
        }
    }
}
