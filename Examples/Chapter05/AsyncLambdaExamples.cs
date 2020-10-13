using System;
using System.Net;
using System.Threading.Tasks;

namespace Examples.Chapter05
{
    class AsyncLambdaExamples
    {
        public static async Task Main()
        {
            const string Url = "https://www.packtpub.com/";

            using var client = new WebClient();

            client.DownloadDataCompleted += async (sender, args) =>
            {
                Logger.Log("Inside DownloadDataCompleted..");
                await Task.Delay(500);
            };
            Logger.Log($"DownloadData: {Url}");
            var data = client.DownloadData(Url);
            Logger.Log($"DownloadData: Length={data.Length:N0}");

            Logger.Log($"DownloadDataTaskAsync: {Url}");
            var downloadTask = client.DownloadDataTaskAsync(Url);
            var downloadBytes =  await downloadTask;
            Logger.Log($"DownloadDataTaskAsync: Length={downloadBytes.Length:N0}");

            Console.ReadLine();
        }

        
    }
}
