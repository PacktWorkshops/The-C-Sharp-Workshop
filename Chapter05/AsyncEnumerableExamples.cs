using System;
using Chapter05.Exercise03;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chapter05
{
    class AsyncEnumerableExamplesProgram
    {
        public static async Task Main()
        {
            //.WithCancellation(cts.Token)
            await foreach (var car in CarSalesAsync(1, 5))
            {
                Logger.Log($"Got {car.Name}/{car.SalePrice:N0}");
            }

            Console.ReadLine();
        }

        private static async IAsyncEnumerable<CarSale> CarSalesAsync(int start, int count)
            {
                var rand = new Random();

                for (var i = start; i < count; i++)
                {
                    Logger.Log($"Sleeping for loop {i}");
                    await Task.Delay(rand.Next(500, 2000));
                    Logger.Log($"Awake for loop {i}");

                    yield return new CarSale($"Car{i}", i * 1000);
                }
            }

        }


}
