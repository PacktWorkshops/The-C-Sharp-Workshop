using System;
using Chapter02.Examples.CsharpKeywords.Operators;

namespace Chapter02.Examples.CsharpKeywords
{
    using static Math;
    public static class Demo
    {
        public static void Run()
        {
            Console.WriteLine(PI);
            Operators.Demo.Run();
            Generics.Demo.Run();
            ExtensionMethods.Demo.Run();
            Struct.Demo.Run();
            Record.Demo.Run();
            Other.Demo.Run();
        } 
    }
}
