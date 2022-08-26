using System;


Console.Write("Enter a number to check whether it is Prime: ");

var input = int.Parse(Console.ReadLine());

Console.WriteLine($"{input} is prime? {IsPrime(input)}.");

static bool IsPrime(int number)
{
    if (number == 0 || number == 1) return false;

    bool isPrime = true;

    int counter = 2;

    while (counter <= Math.Sqrt(number))
    {
        if (number % counter == 0)
        {
            isPrime = false;
            break;
        }

        counter++;
    }

    return isPrime;
}