using System;
using Chapter06.Exercises.Exercise04;

namespace Chapter06
{
    class Program
    {
        public static string GlobalFactoryConnectionString { get; } = Environment.GetEnvironmentVariable("GlobalFactory", EnvironmentVariableTarget.User);
        public static string AdventureWorksConnectionString { get; } = Environment.GetEnvironmentVariable("AdventureWorks", EnvironmentVariableTarget.User);
        public static string TruckLogisticsConnectionString { get; } = Environment.GetEnvironmentVariable("TruckLogistics", EnvironmentVariableTarget.User);

        static void Main(string[] args)
        {
            //Chapter06.Examples.Repository.Demo.TestSqlite();
            //Chapter06.Examples.Cqrs.Demo.Test();
            //Chapter06.Exercises.Exercise03.Demo.Run();
            //Chapter06.Exercises.Exercise04.Demo.Run();
            //Chapter06.Examples.PerformanceTraps.Demo.Run();
            //Chapter06.Examples.TalkingWithDb.Orm.Demo.Run();
            Chapter06.Examples.PerformanceTraps.Demo.Run();
            //Chapter06.Activities.Activity01.Demo.Run();
        }
    }
}
