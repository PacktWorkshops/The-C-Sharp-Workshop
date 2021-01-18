using System.Linq;
using Chapter06.Examples.TalkingWithDb.Raw;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter06
{
    [TestClass]
    public class GetAllProductsQueryHandlerTests
    {
        [TestMethod]
        public void GetAllProducts_ReturnsAllProducts()
        {
            var queryHandler = new GetAllProductsQueryHandler();
            
            var products = queryHandler.GetAllProducts();

            Assert.AreEqual(2, products.Count());
        }
    }
}
