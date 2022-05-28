using System;
using System.Threading.Tasks;

namespace Chapter08.Examples.GitHttp
{
    public static class Demo
    {
        private static string GitHubPersonAccessToken { get; } = Environment.GetEnvironmentVariable("GitHubPersonalAccess", EnvironmentVariableTarget.User);

        public static async Task Run()
        {
            //await GitExamples.GetUser();

            var oathAccessToken = await GitExamples.GetToken();
            await GitExamples.UpdateEmploymentStatus(true, oathAccessToken);

            await GitExamples.UpdateEmploymentStatus(false, GitHubPersonAccessToken);

            var basicToken = GitExamples.GetBasicToken();
            await GitExamples.GetUser61Times(basicToken);
            //await GitExamples.GetUser61Times(); 

            GitExamples.Dispose();
        }
    }
}