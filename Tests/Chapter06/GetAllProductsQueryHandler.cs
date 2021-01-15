using System.Linq;
using Chapter06.Examples._01_Talking_With_Db_The_Old_Way;
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
