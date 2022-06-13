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
            //Examples.Cqrs.Demo.Test();
            //Exercises.Exercise01.Demo.Run();
            //Exercises.Exercise02.Demo.Run();
            //Exercises.Exercise03.Demo.Run();
            Exercises.Exercise04.Demo.Run();
            //Examples.Crud.Demo.Run();
            //Examples.PerformanceTraps.Demo.Run();
            //Examples.TalkingWithDb.Orm.Demo.Run();
            //Examples.TalkingWithDb.Raw.Demo.Run();
            //Examples.TestingDb.Demo.Run();
            //Activities.Activity01.Demo.Run();

        }

        private static string GetEnvironmentVariableOrThrow(string environmentVariable)
        {
            var variable = Environment.GetEnvironmentVariable(environmentVariable, EnvironmentVariableTarget.User);
            if (string.IsNullOrWhiteSpace(variable))
            {
                throw new ArgumentException($"Environment variable {environmentVariable} not found.");
            }

            return variable;
        }
    }
}
