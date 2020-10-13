using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter03Examples
{
    class CaptureExamples
    {
        public static void Main()
        {
            var word = "hello";
            Func<int, string> joiner = reps => string.Join(",", Enumerable.Repeat(word, reps));
            Console.WriteLine($"Outer Variables: {joiner(2)}");

            word = "goodbye";
            Console.WriteLine($"Outer Variables Part2: {joiner(2)}");


            Func<int, string> joinerLocal = reps =>
            {
                var word = "local";
                return string.Join(",", Enumerable.Repeat(word, reps));
            };
            Console.WriteLine($"JoinerLocal: {joinerLocal(2)}");
            Console.WriteLine($"JoinerLocal: word={word}");

            var actions = new List<Action>();
            for (var i = 0; i < 5; i++)
            {
                actions.Add(() => Console.WriteLine($"MyAction: i={i}"));
            }

            foreach (var action in actions)
            {
                action();
            }

            var actionsSafe = new List<Action>();
            for (var i = 0; i < 5; i++)
            {
                var closurei = i;
                actionsSafe.Add(() => Console.WriteLine($"MyAction: closurei={closurei}"));
            }
            foreach (var action in actionsSafe)
            {
                action();
            }
        }
    }
}
