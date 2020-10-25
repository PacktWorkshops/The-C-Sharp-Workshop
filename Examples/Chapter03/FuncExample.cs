using System;

namespace Chapter03Examples
{
    class FuncExample
    {
        public static void Main()
        {
            Func<string, string> emailFormatter = RemoveDots;

            const string Address = "admin@google.com";

            var first = emailFormatter(Address);
            Console.WriteLine($"First={first}");

            emailFormatter += RemoveAtSign;

            var second = emailFormatter(Address);
            Console.WriteLine($"Second={second}");

            Console.ReadLine();
        }

        private static string RemoveAtSign(string address)
        {
            return address.Replace("@", "");
        }

        private static string RemoveDots(string address)
        {
            return address.Replace(".", "");
        }
    }

}
