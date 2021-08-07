using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace Chapter08.Examples.GitOctokit
{
    public static class Demo
    {
        public static async Task Run()
        {
            var github = new GitHubClient(new ProductHeaderValue("Packt"));
            const string username = "Almantask";
            var user = await github.User.Get(username);
            Console.WriteLine($"{username} created profile at {user.CreatedAt}");
        }
    }
}
