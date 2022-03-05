using System;


Console.Write("Enter a number to check whether it is Prime: ");

var input = int.Parse(Console.ReadLine());

Console.WriteLine($"{input} is prime? {IsPrime(input)}.");

static bool IsPrime(int number)
{
    if (number == 0) return false;

    bool isPrime = true;

    int counter = 2;

    while (counter <= number / 2)
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