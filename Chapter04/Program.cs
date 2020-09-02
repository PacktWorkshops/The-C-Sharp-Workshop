using System;

namespace Chapter04
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = Inventory.GetSampleProducts();

            var lowPrice = Prompt("Enter the low price: ", s => Convert.ToDecimal(s));
            var highPrice = Prompt("Enter the high price: ", s => Convert.ToDecimal(s));
            Inventory.ShowProductsInPriceRange(products, lowPrice, highPrice);
        }

        private static T Prompt<T>(string message, Func<string, T> convertResult)
        {
            Console.Write(message);
            string result = Console.ReadLine();
            return convertResult.Invoke(result);
        }
    }
}
