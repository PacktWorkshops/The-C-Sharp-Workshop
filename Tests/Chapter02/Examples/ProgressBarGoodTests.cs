using Chapter02.Examples.Abstraction.Progress;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter02.Examples
{
    [TestClass]
    public class ProgressBarGoodTests
    {
        [DataTestMethod]
        [DataRow(1f, 1f, true)]
        [DataRow(0f, 1f, false)]
        [DataRow(2f, 1f, true)]
        [DataRow(0.999f, 1f, true)]
        [DataRow(0.99f, 1f, false)]
        public void IsComplete_Returns_WhetherCurrentIsCloseToMax(float current, float max, bool expectedIsComplete)
        {
            var bar = new ProgressBarGood(current, max);

            var isComplete = bar.IsComplete;

            Assert.AreEqual(expectedIsComplete, isComplete);
        }

        [DataTestMethod]
        [DataRow(1f,0f,0f)]
        [DataRow(1f,1f,1f)]
        [DataRow(2f,1f,1f)]
        [DataRow(0f, 1f, 0f)]
        public void SetCurrentProgress_IsAsExpected(float maxProgress, float newProgress, float expectedProgress)
        {
            var bar = new ProgressBarGood(0, maxProgress);

            bar.Current = newProgress;

            Assert.AreEqual(expectedProgress, bar.Current);
        }
    }
}
