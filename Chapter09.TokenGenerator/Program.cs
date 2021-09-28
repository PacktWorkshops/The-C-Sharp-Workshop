using System;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Chapter09.TokenGenerator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Press enter to regenerate a token");
                Console.WriteLine();
                Console.ReadLine();
                var token = await GetAuthorizationToken();
                Console.WriteLine(token);
            }
        }

        public static async Task<string> GetAuthorizationToken()
        {
            ClientCredential cc = new ClientCredential("56dd489b-07e6-4469-9318-1bba3f5d644a", "zd_7Q~jrD8rvAWG5Q_EgFPZGcfTVhg.fC5~63");
            var context = new AuthenticationContext("https://login.microsoftonline.com/" + "ddd0fd18-f056-4b33-88cc-088c47b81f3e");
            var result = await context.AcquireTokenAsync("56dd489b-07e6-4469-9318-1bba3f5d644a", cc);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to obtain the Access token");
            }
            return $"Bearer {result.AccessToken}";
        }
    }
}
