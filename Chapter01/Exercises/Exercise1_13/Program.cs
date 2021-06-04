using System;

bool divisionExecuted = false;

while (!divisionExecuted)
{
    try
    {
        Console.WriteLine("Please input a number");

        var a = int.Parse(Console.ReadLine());

        Console.WriteLine("Please input another number");

        var b = int.Parse(Console.ReadLine());

        var result = Divide(a, b);

        Console.WriteLine($"Result: {result}");

        divisionExecuted = true;
    }
    catch (System.FormatException)
    {
        Console.WriteLine("You did not input a number. Let's start again ... \n");
        continue;
    }
    catch (System.DivideByZeroException)
    {
        Console.WriteLine("Tried to divide by zero. Let's start again ... \n");
        continue;
    }
}

static double Divide(int a, int b)
{
    return a / b;
}