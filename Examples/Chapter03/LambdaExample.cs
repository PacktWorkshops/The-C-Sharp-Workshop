using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter03Examples
{
    class LambdaExample
    {
        public static void Main1()
        {

            var names = new List<string>
            {
                "BATMAN BEGINS",
                "it",
                "The A-Team",
                "Blade Runner",
                "There's Something About Mary",
                "The Crow"
            };

            names.Sort(delegate (string s, string s1)
               {
                   return string.Compare(s, s1, StringComparison.InvariantCultureIgnoreCase);
               });

            //      Console.WriteLine(string.Join(Environment.NewLine, names));

            names.Sort(delegate (string s, string s1)
            {
                return string.Equals(s, "Blade Runner", StringComparison.CurrentCultureIgnoreCase)
                    ? -1
                    : string.Compare(s, s1, StringComparison.InvariantCultureIgnoreCase);
            });

            names.Sort(delegate { return 1; });

            names.Sort(delegate (string s, string s1) { return string.Compare(s, s1); }); // abvoie but as methd gropu
            names.Sort(string.Compare); 

            names.Sort(delegate (string s, string s1) { return MyComparison(s, s1); });
            names.Sort(MyComparison);


            names.Sort((s, s1) =>
            {
                return string.Compare(RemoveNoiseWord(s), RemoveNoiseWord(s1), StringComparison.InvariantCultureIgnoreCase);
            });

            names.Sort((s, s1) => string.Compare(RemoveNoiseWord(s), RemoveNoiseWord(s1), StringComparison.InvariantCultureIgnoreCase));

            names.Sort((string s, string s1) => string.Compare(RemoveNoiseWord(s), RemoveNoiseWord(s1), StringComparison.InvariantCultureIgnoreCase));

            static int LocalComparison(string s, string s1)
                => string.Compare(RemoveNoiseWord(s), RemoveNoiseWord(s1), StringComparison.InvariantCultureIgnoreCase);
            names.Sort(LocalComparison);

            var numbers = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven" };
            var items = numbers.Where((string s, int i) => s != "zero" && i % 2 == 0).ToList();
        }

        private static string RemoveNoiseWord(string word)
        {
            const string Noise = "the ";
            return word.StartsWith(Noise, StringComparison.InvariantCultureIgnoreCase)
                ? word.Substring(Noise.Length)
                : word;
        }
        private static int MyComparison(string x, string y)
        {
            return 1;
        }

    }

}

