using System;
using Chapter06.Examples._01_Talking_With_Db_The_Old_Way;

namespace Chapter06
{
    class Program
    {
        public const string ConnectionString = "Server=ak2020.database.windows.net;Database=GlobalFactory2020;User Id=AlmantasK;Password=Mocking-Bird415;";

        static void Main(string[] args)
        {
            var query = new GetAllProductsQueryHandler();
            var products = query.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} {product.Id} {product.Price}");
            }
        }
    }
}
