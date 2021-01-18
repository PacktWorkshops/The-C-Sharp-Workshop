using System;

namespace Chapter06.Examples.TalkingWithDb.Raw
{
    public static class Demo
    {
        public static void Run()
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
