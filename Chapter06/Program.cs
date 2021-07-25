using System;
using Chapter06.Activities.Activity01;

namespace Chapter06
{
    class Program
    {
        public static string GlobalFactoryConnectionString { get; } = Environment.GetEnvironmentVariable("GlobalFactory", EnvironmentVariableTarget.User);
        public static string AdventureWorksConnectionString { get; } = Environment.GetEnvironmentVariable("AdventureWorks", EnvironmentVariableTarget.User);

        static void Main(string[] args)
        {
            Chapter06.Examples.Repository.Demo.TestSqlite();
            //Chapter06.Examples.CQRS.Demo.Test();
            //Chapter06.Exercises.Exercise03.Demo.Run();
            //Chapter06.Examples.PerformanceTraps.Demo.Run();
            //var repo = new ProductRepository(new FactoryDbContext());
            //var products = repo.GetByManufacturer(1);
            //foreach (var product in products)
            //{
            //    Console.WriteLine($"{product.Name} {product.Id} {product.Price}"); 
            //}
            //Chapter06.Examples.TalkingWithDb.Orm.Demo.Run();
            //Exercises.Exercise03.Demo.Run();
            //Chapter06.Examples.PerformanceTraps.Demo.Run();
        }
    }
}
