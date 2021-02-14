using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Chapter04.Exercises.Exercise04
{
    class TextCounter
    {
        private readonly HashSet<string> _stopWords;

        public TextCounter(string stopWordPath)
        {
            Console.WriteLine($"Reading stop word file: {stopWordPath}");
            _stopWords = new HashSet<string>(File.ReadAllLines(stopWordPath));
        }

        public IEnumerable<Tuple<string, int>> Process(string text, int maximumWords)
        {
            var words = Regex.Split(text.ToLower(), @"\s+")
                .Where(t => !_stopWords.Contains(t))
                .GroupBy(t => t)
                .Select(grp => Tuple.Create(grp.Key, grp.Count()))
                .OrderByDescending(tup => tup.Item2) //int
                .Take(maximumWords);

            return words;
        }

    }

    class Program
    {
        public static void Main()
        {
            const string StopWordFile = "StopWords.txt";
            var counter = new TextCounter(StopWordFile);

            string address;
            do
            {
                //https://www.gutenberg.org/files/64333/64333-0.txt
                Console.Write("Enter a Gutenberg book URL: ");
                address = Console.ReadLine();

                if (string.IsNullOrEmpty(address)) 
                    continue;

                using var client = new WebClient();
                var tempFile = Path.GetTempFileName();
                Console.WriteLine("Downloading...");
                client.DownloadFile(address, tempFile);

                Console.WriteLine($"Processing file {tempFile}");
                const string StartIndicator = "*** START OF THE PROJECT GUTENBERG EBOOK";
                //Title: The Little Review, October 1914(Vol. 1, No. 7)
                //Author: Various

                var title = string.Empty;
                var author = string.Empty;
                var bookText = new StringBuilder();
                var isReadingBookText = false;
                var bookTextLineCount = 0;
                foreach (var line in File.ReadAllLines(tempFile))
                {
                    if (line.StartsWith("Title"))
                    {
                        title = line;
                    }
                    else if (line.StartsWith("Author"))
                    {
                        author = line;
                    }
                    else if (line.StartsWith(StartIndicator))
                    {
                        isReadingBookText = true;
                    }
                    else if (isReadingBookText)
                    {
                        bookText.Append(line);
                        bookTextLineCount++;
                    }
                }

                if (bookTextLineCount > 0)
                {
                    Console.WriteLine($"Processing {bookTextLineCount:N0} lines ({bookText.Length:N0} characters)..");
                    var wordCounts = counter.Process(bookText.ToString(), 50);
                    Console.WriteLine(title);
                    Console.WriteLine(author);

                    var i = 0;
                    //deconstruction
                    foreach (var (word, count) in wordCounts)
                    {
                        Console.Write($"'{word}'={count}\t\t");
                        i++;
                        if (i % 3 == 0)
                        {
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"Failed to find start of book text using {StartIndicator}");
                }

            } while (address != string.Empty);
        }
    }
}
