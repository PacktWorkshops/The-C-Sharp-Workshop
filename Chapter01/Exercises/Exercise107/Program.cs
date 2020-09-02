using System;

public class Program
{
    public static void Main()
    {
        var menuBuilder = new System.Text.StringBuilder();

        menuBuilder.AppendLine("Welcome to the Burger Joint. ");
        menuBuilder.AppendLine(string.Empty);
        menuBuilder.AppendLine("1) Burgers and Fries - 5 USD");
        menuBuilder.AppendLine("2) Cheeseburger - 7 USD");
        menuBuilder.AppendLine("3) Double-cheeseburger - 9 USD");
        menuBuilder.AppendLine("4) Coke - 2 USD");
        menuBuilder.AppendLine(string.Empty);
        menuBuilder.AppendLine("Note that every burger option comes with fries and ketchup!");

        Console.WriteLine(menuBuilder.ToString());

        Console.WriteLine("Please type one of the follow options to order:");

        var option = Console.ReadKey();

        switch(option.KeyChar.ToString())
        {
            case "1":
            {
                Console.WriteLine("\nAlright, some burgers on the go! Please pay on the following cashier!");
                break;
            }
            case "2":
            {
                Console.WriteLine("\nI got you, I also like some cheese. Cheeseburgers on the go! Please pay on the following cashier!");
                break;
            }
            case "3":
            {
                Console.WriteLine("\nWow, seems you're hungry! Some double cheeseburgers on the go! Please pay on the following cashier!");
                break;
            }
            case "4":
            {
                Console.WriteLine("\nA freezing Coke for you! Please pay on the following cashier!");
                break;
            }
            default:
            {
                Console.WriteLine("\nSorry, you chosen an inexistent option.");
                break;
            }
        }
    }
}
