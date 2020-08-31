using System;
using System.Linq;

namespace Chapter3
{
    public static class ActionHelpers
    {
        public static void InvokeAll<T>(Action<T> logger, T arg)
        {
            if (logger == null)
                return;

            var actions = logger.GetInvocationList().OfType<Action<T>>();
            foreach (var act in actions)
            {
                try
                {
                    Console.WriteLine($"Invoking '{act.Method.Name}'");
                    act(arg);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }
        
    }
   
}