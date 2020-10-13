using System;

namespace Chapter03Examples

{
    class ActionExamples
    {
        public delegate void NoArgsDelegate();
        public delegate void OneArgDelegate(string arg1);
        public delegate void TwoArgDelegate(string arg1, double arg2);
        public delegate void ThreeArgDelegate(string arg1, double arg2, int arg3);

        delegate string NoArgsFuncDelegate();

        delegate int OneArgFuncDelegate(string arg1);

        delegate bool TwoArgFuncDelegate(string arg1, double arg2);

        delegate DateTime ThreeArgFuncDelegate(string arg1, double arg2, int arg3);

        public static void Main()
        {
            Func<string> func1;
            Func<string, double, bool> func2;
            Func<string, double, int, DateTime> func3;

            Action<string, int> logger = LogToConsole1;
            logger += LogToConsole2;

            logger("Here we go", 99);

            static void LogToConsole1(string message, int num)
               => Console.WriteLine($"Log1:{message}, n={num}");

            static void LogToConsole2(string message, int num)
               => Console.WriteLine($"Log2:{message}, n={num}");

        }

        //private static void LogToConsole1(string message, int num)
        //  => Console.WriteLine($"Log1:{message}, n={num}");

        //private static void LogToConsole2(string message, int num)
        //  => Console.WriteLine($"Log2:{message}, n={num}");
    }

}
