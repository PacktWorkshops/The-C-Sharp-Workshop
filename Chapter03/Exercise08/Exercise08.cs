using System;
using System.Linq;

namespace Chapter3
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
                        .Split(Delimit, StringSplitOptions.RemoveEmptyEntries)
                        .Reverse();

                    return string.Join(Delimit, words);
                };

            return swapWords(sentence);
        }
    }
}
