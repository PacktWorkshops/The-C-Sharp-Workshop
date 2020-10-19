using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;

namespace Chapter03.Activity01
{
    public class EventArgsValue<T>
    {
        public EventArgsValue(T value)
        {
            Value = value;
        }
        public T Value { get; }
    }

    public class DownloadProgressChangedEventArgs : ProgressChangedEventArgs
    {
        public DownloadProgressChangedEventArgs(int progressPercentage, long bytesReceived)
            : base(progressPercentage, null)
        {
            BytesReceived = bytesReceived;
        }
        public long BytesReceived { get; }
    }

    public interface IWebClient
    {
        event EventHandler DownloadCompleted;
        event EventHandler<DownloadProgressChangedEventArgs> DownloadProgressChanged;
        event EventHandler<EventArgsValue<string>> InvalidUrlRequested;
        IDisposable DownloadFile(string url, string destination);
    }
    public interface IWebClientFactory
    {
        IWebClient GetClient();
    }

    public class WebClientAdapter : IWebClient
    {
        public event EventHandler DownloadCompleted;
        public event EventHandler<DownloadProgressChangedEventArgs> DownloadProgressChanged;
        public event EventHandler<EventArgsValue<string>> InvalidUrlRequested;

        public IDisposable DownloadFile(string url, string destination)
        {
            Uri uri;
            if (!Uri.TryCreate(url, UriKind.Absolute, out uri))
            {
                InvalidUrlRequested?.Invoke(this, new EventArgsValue<string>(url));
                return null;
            }

            var client = new WebClient();

            client.DownloadFileCompleted += (sender, args) =>
                DownloadCompleted?.Invoke(this, EventArgs.Empty);

            client.DownloadProgressChanged += (sender, args) =>
                DownloadProgressChanged?.Invoke(this,
                    new DownloadProgressChangedEventArgs(args.ProgressPercentage, args.BytesReceived));

            client.DownloadFileAsync(uri, destination);

            return client;
        }
    }

    public class WebClientFactory : IWebClientFactory
    {
        public IWebClient GetClient()
        {
            return new WebClientAdapter();
        }
    }

    public class WebDownloader
    {
        private readonly IWebClientFactory _webClientFactory;

        public WebDownloader(IWebClientFactory webClientFactory)
        {
            _webClientFactory = webClientFactory;
        }

        public void DownLoad(string url, string destination)
        {
            var client = _webClientFactory.GetClient();

            var waiter = new ManualResetEventSlim();
            using (waiter)
            {
                client.InvalidUrlRequested += (sender, args) =>
                {
                    var oldColor = Console.BackgroundColor;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Invalid URL {args.Value}");
                    Console.BackgroundColor = oldColor;
                };

                client.DownloadProgressChanged += (sender, args) =>
                {
                    Console.WriteLine($"Downloading...{args.ProgressPercentage}% complete ({args.BytesReceived:N0} bytes)");
                };

                client.DownloadCompleted += (sender, args) =>
                {
                    Console.WriteLine($"Downloaded to {destination} ");
                    waiter.Set();
                };

                Console.WriteLine($"Downloading {url}...");
                var disposable = client.DownloadFile(url, destination);
                if (disposable == null) return;

                using (disposable)
                {
                    if (waiter.Wait(TimeSpan.FromSeconds(10D)))
                    {
                        Console.WriteLine($"Launching {destination}");
                        Process.Start("explorer.exe", destination);
                    }
                    else
                    {
                        Console.WriteLine($"Timedout downloading {url}");
                    }
                }
            }
        }
    }

    public class Activity01Program
    {
        public static void Main()
        {
            var downloader = new WebDownloader(new WebClientFactory());

            var input = string.Empty;
            do
            {
                Console.WriteLine("Enter a URL:");
                input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
                    string destination;
                    var lastSlash = input.LastIndexOf("/");
                    if (lastSlash > -1)
                    {
                        destination = Path.Join(Path.GetTempPath(), input.Substring(lastSlash + 1));
                    }
                    else
                    {
                        destination = Path.GetTempFileName();
                    }

                    downloader.DownLoad(input, destination);

                }
            } while (input != string.Empty);
        }
    }

}
