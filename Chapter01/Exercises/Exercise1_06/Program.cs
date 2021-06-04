using System;
using System.Linq;

Console.WriteLine("Please type a username. It must have at least 6 digits: ");

var username = Console.ReadLine();

if (username.Length < 6)
{
    Console.WriteLine($"The username {username} is not valid.");
}
else
{
    Console.WriteLine("Now type a password. It must have a least 6 digits and a number");

    var password = Console.ReadLine();

    if (password.Length < 6)
    {
        Console.WriteLine("The password must have at least 6 digits.");
    }
    else if (!password.Any(c => char.IsDigit(c)))
    {
        Console.WriteLine("The password must contain a least one number.");
    }
    else
    {
        Console.WriteLine("User successfully registered.");
    }
}
