using System;
using Chapter06.Examples.TalkingWithDb.Orm;

namespace Chapter06
{
    class Program
    {
        public static string ConnectionString { get; } = Environment.GetEnvironmentVariable("GlobalFactory", EnvironmentVariableTarget.User);

        static void Main(string[] args)
        {
            Demo.Run();
        }
    }
}
