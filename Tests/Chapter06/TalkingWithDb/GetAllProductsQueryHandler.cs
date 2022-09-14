using System.Linq;
using Chapter06.Examples.TalkingWithDb.Raw;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter06.TalkingWithDb
{
    [TestClass]
    public class GetAllProductsQueryHandlerTests
    {
        [TestMethod]
        public void GetAllProducts_ReturnsAllProducts()
        {
            var queryHandler = new GetAllProductsQueryHandler();

            var products = queryHandler.GetAllProducts();

            Assert.IsTrue(products.Any(), "Products count should be more than 0.");
        }
    }
}
