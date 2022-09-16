using System.Linq;
using System.Threading.Tasks;
using Chapter05.Exercises.Exercise05;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter05
{
    [TestClass]
    public class Exercise05Tests
    {

        [TestMethod]
        public async Task Fetch_RanToCompletion()
        {
            var ops = new CustomerOperations();
            var resultTask = ops.FetchTopCustomers();

            var customers = await resultTask;

            Assert.AreEqual(resultTask.Status, TaskStatus.RanToCompletion);
            Assert.IsNull(resultTask.Exception);
            Assert.IsTrue(customers.All(c => c.Region != CustomerOperations.ProtectedRegion));

        }

    }

}

