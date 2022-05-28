using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter08.Common
{
    public static class EnvironmentVariable
    {
        public static string GetOrThrow(string environmentVariable)
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
