using RestSharp;
using RestSharp.Serializers.SystemTextJson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exercise01 = Chapter08.Exercises.Exercise01;
using GithubHttp = Chapter08.Examples.GitHttp;
using GithubOcto = Chapter08.Examples.GitOctokit;

namespace Chapter08
{
    class Program
    {
        public static string TextAnalysisApiKey { get; } = Environment.GetEnvironmentVariable("TextAnalysisApiKey", EnvironmentVariableTarget.User);
        public static string TextAnalysisEndpoint { get; } = Environment.GetEnvironmentVariable("TextAnalysisEndpoint", EnvironmentVariableTarget.User);
        public static string GitHubClientId { get; } = Environment.GetEnvironmentVariable("GithubClientId", EnvironmentVariableTarget.User);
        public static string GitHubSecret { get; } = Environment.GetEnvironmentVariable("GithubSecret", EnvironmentVariableTarget.User);
        public static string GitHubPersonAccessToken { get; } = Environment.GetEnvironmentVariable("GitHubPersonalAccess", EnvironmentVariableTarget.User);

        static async Task Main(string[] args)
        {
            // await GithubOcto.Demo.Run();
            //await GithubHttp.Demo.Run();
            // Exercise01.Demo.Run();
            //Exercises.Exercise02.Demo.Run();
            //Examples.BaseHttp.Demo.Run();
            //Examples.RESTSharp.Demo.Run();
            //Examples.REfit.Demo.Run();
            Exercises.Exercise03.Demo.Run();
        }
    }
}
