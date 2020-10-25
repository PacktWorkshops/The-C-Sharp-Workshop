using System;
using System.Linq;

namespace Chapter03.Exercise06
{

    public static class WordUtilities
    {
        public static string ReverseWords(string sentence)
        {
            Func<string, string> swapWords =
                phrase =>
                {
                    const char Delimit = ' ';
                    var words = phrase
                        .Split(Delimit)
                        .Reverse();

                    return string.Join(Delimit, words);
                };

            return swapWords(sentence);
        }
    }

    public static class Program
    {
        public static void Main()
        {
            do
            {
                Console.Write("Enter a sentence:");
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                var result = WordUtilities.ReverseWords(input);
                Console.WriteLine($"Reversed: {result}");

            } while (true);
        }
    }
}