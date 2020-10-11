using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter08.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// splits a string into an enumerable based on a delegate rather than a hard-coded value
        /// </summary>
        public static IEnumerable<string> SplitWhere(this string input, Func<char, int, bool> criteria)
        {
            StringBuilder result = new StringBuilder();
            for (int position = 0; position < input.Length; position++)
            {                
                if (!criteria.Invoke(input[position], position))
                {
                    result.Append(input[position]);
                    // at the end of input, return what you have
                    if (position == input.Length - 1) yield return result.ToString();
                }
                else
                {
                    yield return result.ToString();
                    // start the next part with the character in current position
                    result = new StringBuilder(input[position].ToString());
                }
            }
        }
    }
}
