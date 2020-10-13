using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Chapter05
{
    class DownloadExamples
    {

        public static async Task Main()
        {
            var urls = new[]
            {
                "https://www.packtpub.com/",
                "https://www.google.com/",
                "https://www.microsoft.com/",
            };
            foreach (var url in urls)
            {
                using var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(url);
                Console.WriteLine($"{url} has {html.Length} characters");
                
            }

            Console.ReadLine();
        }
    }
}
