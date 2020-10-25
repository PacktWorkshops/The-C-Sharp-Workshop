using System;
using System.IO;
using System.Threading;
using Chapter03.Activity01;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter03
{

    [TestClass]
    public class Activity01Tests
    {
        [TestMethod]
        public void WebClientAdapter_DownLoad()
        {
            var downloadProgressChangedMessages = string.Empty;
            var downloadCompleteddMessages = string.Empty;

            var client = new WebClientAdapter();
            var waiter = new ManualResetEventSlim();
            using (waiter)
            {
                client.DownloadProgressChanged += (sender, args) =>
                {
                    downloadProgressChangedMessages +=  "Downloading...";
                };

                client.DownloadCompleted += (sender, args) =>
                {
                    downloadCompleteddMessages += "Downloaded";
                    waiter.Set();
                };

                var destination = Path.GetTempFileName();
                const string Url =
                    @"https://www1.ncdc.noaa.gov/pub/data/swdi/stormevents/csvfiles/StormEvents_details-ftp_v1.0_d1950_c20170120.csv.gz";
                var request = client.DownloadFile(Url, destination);
                if (request == null)
                    return;

                using (request)
                {
                    Assert.IsTrue(waiter.Wait(TimeSpan.FromSeconds(10D)));
                    Assert.IsFalse(string.IsNullOrEmpty(downloadProgressChangedMessages));
                    Assert.IsFalse(string.IsNullOrEmpty(downloadCompleteddMessages));
                    Assert.IsTrue(File.Exists(destination));
                }
            }
        }
    }
}
