using System;

namespace Examples.Chapter03
{
    public class ActionOrFuncDelegateExamples
    {
        public delegate string DoStuff(string name, int age);
        public delegate string DoMoreStuff(string name, int age);

public static void Main()
{
    DoStuff stuff = new DoStuff(MyMethod);
    DoMoreStuff moreStuff = MyMethod;
    
    Console.WriteLine($"Stuff: {stuff("Louis", 2)}");
    Console.WriteLine($"MoreStuff: {moreStuff("Louis", 2)}");

    Func<string, int, string> funcStuff = MyMethod;
    Console.WriteLine($"FuncStuff: {funcStuff("Louis", 2)}");
    Console.ReadLine();

}

private static string MyMethod(string name, int age)
{
    return $"{name}@{age}";
}
    }
}
