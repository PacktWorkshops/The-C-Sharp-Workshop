using System;

namespace Chapter06
{
    class Program
    {
        public static string GlobalFactoryConnectionString { get; } = GetEnvironmentVariableOrThrow("GlobalFactory");
        public static string AdventureWorksConnectionString { get; } = GetEnvironmentVariableOrThrow("AdventureWorks");
        public static string TruckLogisticsConnectionString { get; } = GetEnvironmentVariableOrThrow("TruckLogistics");

        static void Main(string[] args)
        {
            //Examples.Repository.Demo.TestSqlite();
            //Examples.Cqrs.Demo.Test();
            //Exercises.Exercise03.Demo.Run();
            //Exercises.Exercise04.Demo.Run();
            //Examples.PerformanceTraps.Demo.Run();
            //Examples.TalkingWithDb.Orm.Demo.Run();
            Examples.PerformanceTraps.Demo.Run();
            //Activities.Activity01.Demo.Run();
        }

        private static string GetEnvironmentVariableOrThrow(string environmentVariable)
        {
            var variable = Environment.GetEnvironmentVariable("TruckLogistics", EnvironmentVariableTarget.User);
            if (string.IsNullOrWhiteSpace(variable))
            {
                throw new ArgumentException($"Environment variable {environmentVariable} not found.");
            }

            return variable;
        }
    }
}
