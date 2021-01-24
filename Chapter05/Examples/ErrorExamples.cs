using System;
using System.Threading.Tasks;

namespace Chapter05.Examples
{
    class ErrorExamplesProgram
    {
        public static async Task Main()
        {
            try
            {
                var operations = new CustomerOperations();
                var discount = await operations.AverageDiscount();
                Logger.Log($"Discount: {discount}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Caught a divide by zero");
            }

            Console.ReadLine();
        }

        class CustomerOperations
        {
            public async Task<int> AverageDiscount()
            {
                Logger.Log("Loading orders...");
                await Task.Delay(TimeSpan.FromSeconds(1));

                var orderCount = new Random().Next(0, 2);
                var orderValue = 1200;
                return orderValue / orderCount;
            }
        }

    }
}
