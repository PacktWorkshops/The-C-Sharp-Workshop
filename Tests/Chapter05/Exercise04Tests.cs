using System;
using System.Threading;
using System.Threading.Tasks;
using Chapter05;
using Chapter05.Exercises.Exercise04;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter05
{

    [TestClass]
    public class Exercise04Tests
    {
        private static readonly TimeSpan DelayTime = TimeSpan.FromSeconds(3);
        private static readonly TimeSpan CancellationTime = DelayTime.Divide(2);

        [TestMethod]
        public async Task Fetch_RanToCompletion()
        {
            Logger.Log("Starting");
            using var tokenSource = new CancellationTokenSource( CancellationTime);
            tokenSource.Token.Register(() => Logger.Log("Cancelled token"));

            var resultTask = new SlowRunningService()
                .Fetch(DelayTime, tokenSource.Token);

            await resultTask;

            Logger.Log($"Result={resultTask.Result}");
            Assert.AreEqual(resultTask.Status, TaskStatus.RanToCompletion);
            Assert.IsNull(resultTask.Exception);
        }
    }
}

