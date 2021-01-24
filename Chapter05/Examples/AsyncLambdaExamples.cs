using System;
using System.Net;
using System.Threading.Tasks;

namespace Chapter05.Examples
{
    class AsyncLambdaExamples
    {
        public static async Task Main()
        {
            const string Url = "https://www.packtpub.com/";

            using var client = new WebClient();

            client.DownloadDataCompleted += async (sender, args) =>
            {
                global::Chapter05.Examples.Logger.Log("Inside DownloadDataCompleted..");
                await Task.Delay(500);
            };
            global::Chapter05.Examples.Logger.Log($"DownloadData: {Url}");
            var data = client.DownloadData(Url);
            global::Chapter05.Examples.Logger.Log($"DownloadData: Length={data.Length:N0}");

            global::Chapter05.Examples.Logger.Log($"DownloadDataTaskAsync: {Url}");
            var downloadTask = client.DownloadDataTaskAsync(Url);
            var downloadBytes =  await downloadTask;
            global::Chapter05.Examples.Logger.Log($"DownloadDataTaskAsync: Length={downloadBytes.Length:N0}");

            Console.ReadLine();
        }

        
    }
}
