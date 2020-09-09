using System;

namespace Exercise108
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the Number to check Prime: ");

            var input = int.Parse(Console.ReadLine());

            Console.WriteLine($"{input} is prime? {IsPrimeWithGoTo(input)}.");
        }

        static bool IsPrime(int number)
        {
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

        static bool IsPrimeWithContinue(int number)
        {
            bool isPrime = true;

            int counter = 2;

            while (counter <= number / 2)
            {
                if (number % counter != 0)
                {
                    counter++;
                    continue;
                }

                isPrime = false;
                break;
            }

            return isPrime;
        }

        static bool IsPrimeWithGoTo(int number)
        {
            bool isPrime = true;

            int counter = 2;

            while (counter <= number / 2)
            {
                if (number % counter == 0)
                {
                    isPrime = false;
                    goto isNotAPrime; 
                }

                counter++;
            }

            isNotAPrime:
            return isPrime;
        }

        static bool IsPrimeWithReturn(int number)
        {
            int counter = 2;

            while (counter <= number / 2)
            {
                if (number % counter == 0)
                {
                    return false;
                }

                counter ++;
            }

            return true;
        }
    }
}
