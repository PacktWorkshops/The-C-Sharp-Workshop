using Chapter08.Models;
using RestSharp;
using RestSharp.Serializers.SystemTextJson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exercise01 = Chapter08.Exercises.Exercise01;
using Github = Chapter08.Examples.GitOctokit;

namespace Chapter08
{
    class Program
    {
        public static string TextAnalysisApiKey { get; } = Environment.GetEnvironmentVariable("TextAnalysisApiKey", EnvironmentVariableTarget.User);
        public static string TextAnalysisEndpoint { get; } = Environment.GetEnvironmentVariable("TextAnalysisEndpoint", EnvironmentVariableTarget.User);

        static async Task Main(string[] args)
        {
            // await Github.Demo.Run();
            Exercise01.Demo.Run();
        }
    }
}
