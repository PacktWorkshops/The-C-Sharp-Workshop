using System;
using System.IO;
using Chapter03.Activity01;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chapter3;

namespace Chapter3UnitTest
{

internal class TestableWebClient : IWebClient
{
    public event EventHandler DownloadCompleted;
    public event EventHandler<DownloadProgressChangedEventArgs> DownloadProgressChanged;
    public event EventHandler<EventArgsValue<string>> InvalidUrlRequested;
    public IDisposable DownloadFile(string url, string destination)
    {
        return null;
    }

    internal TestableWebClient InvokeDownloadCompleted()
    {
        DownloadCompleted?.Invoke(this, EventArgs.Empty);
        return this;
    }

    internal TestableWebClient InvokeDownloadProgressChanged(int progress, long bytes)
    {
        DownloadProgressChanged?.Invoke(this, 
            new DownloadProgressChangedEventArgs(progress, bytes));
        return this;
    }
}

    internal class TestableWebClientFactory : IWebClientFactory
    {
        public TestableWebClientFactory()
        {
            TestClient = new TestableWebClient();    
        }
        public TestableWebClient TestClient { get; }

        public IWebClient GetClient()
        {
            return TestClient;
        }
    }

    [TestClass]
    public class Activity01Tests
    {
        [TestMethod]
        public void WebDownloader_DownLoad()
        {
            // ARRANGE
            using var writer = new StringWriter();
            Console.SetOut(writer);
            
            var webClientFactory = new TestableWebClientFactory();
            // ACT
            var downloader = new WebDownloader(webClientFactory);
            downloader.DownLoad("some web file","myfile.csv");

            webClientFactory.TestClient
                .InvokeDownloadProgressChanged(10, 1024)
                .InvokeDownloadProgressChanged(100, 1024 * 100)
                .InvokeDownloadCompleted();

            writer.Flush();// Ensure writer is flushed

            // ASSERT
            var expectedOutput = new[]
            {
                "Downloading some web file...",
                "Downloading...10% complete (1,024 bytes)",
                "Downloading...100% complete (102,400 bytes)",
                "Downloaded to myfile.csv ",
                string.Empty
            };

            var actualConsoleLines = writer.ToString().Split(Environment.NewLine);
            CollectionAssert.AreEqual(expectedOutput, actualConsoleLines);
        }
    }
}
