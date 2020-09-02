using System;

class Program
{
    static void Main(string[] args)
    {
        // 1.	A program generates a random number between 1 and 10. This number is not outputted to the console.
        // 2.	The console asks the user for a number input
        // 3.	The user has 5 chances. If a chance is missed, the user must be warned of how many chances are a left and must be prompted to try again.
        // 4.	If the number is guessed correctly, give a success message and terminate the program.
        // 5.	If there are no more chances, give a warning message and terminate the program.

        var numberToBeGuessed = new Random().Next(0, 10);
        var remainingChances = 5;
        var numberFound = false;

        Console.WriteLine("Welcome to Packt's C# Workshop Guessing Game! :D");

        while (remainingChances > 0 && !numberFound)
        {
            Console.WriteLine($"\n You have {remainingChances} chances! Please type a number between 0 and 10 to try to guess the number that I generated for you!");

            var number = int.Parse(Console.ReadLine());

            if (number == numberToBeGuessed)
            {
                numberFound = true;
            }
            else
            {
                remainingChances--;
            }
        }

        if (numberFound)
        {
            Console.WriteLine($"Congrats! You've guessed the number with {remainingChances} chances left!");
        }
        else
        {
            Console.WriteLine($"Oh, it wasn't this time! The number was {numberToBeGuessed}. You're out of chances. :(");
        }
    }
}
