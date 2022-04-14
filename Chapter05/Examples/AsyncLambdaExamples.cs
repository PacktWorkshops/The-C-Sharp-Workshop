using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Chapter05.Examples
{
    public class AsyncLambdaExamples
    {
        public static async Task Main()
        {
            const string Url = "https://www.packtpub.com/";

            using var client = new WebClient();

            client.DownloadDataCompleted += async (sender, args) =>
            {
                Logger.Log("Inside DownloadDataCompleted...looking busy");
                await Task.Delay(500);
                Logger.Log("Inside DownloadDataCompleted..all done now");
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
