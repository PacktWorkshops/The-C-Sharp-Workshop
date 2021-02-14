using System;
using System.IO;
using System.Linq;

namespace Chapter04.Activities.Activity01
{
    class Program
    {
        public static void Main()
        {
            const string FlightDataUrl = "https://www.gov.uk/government/uploads/system/uploads/attachment_data/file/245855/HMT_-_2011_Air_Data.csv";
            const string FlightDataFilePath = "hm-treasury-flight-data-2011.csv";

            var flightQuery = new FlightQuery(new FlightLoader());

            if (File.Exists(FlightDataFilePath))
            {
                Console.WriteLine($"Importing {FlightDataFilePath}");
                flightQuery.Import(FlightDataFilePath);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Downloading {FlightDataUrl}");
                flightQuery.Download(FlightDataUrl, FlightDataFilePath);
                Console.WriteLine();
                Console.WriteLine($"Downloaded to {FlightDataFilePath}...");
            }

            Console.WriteLine($"Found {flightQuery.Count} flight records");

            const string GoCommand = "go";
            const string ClearCommand = "clear";
            const string ClassCommand = "class";
            const string OriginCommand = "origin";
            const string DestinationCommand = "destination";

            Console.WriteLine($"Commands: {GoCommand} | {ClearCommand} | {ClassCommand} value | {OriginCommand} value | {DestinationCommand} value");
            string input;
            do
            {
                Console.Write("Enter a command:");
                input = Console.ReadLine().ToLower();

                string command;
                string argument;
                var spaceIndex = input.IndexOf(' ');
                if (spaceIndex == -1)
                {
                    command = input;
                    argument = null;
                }
                else
                {
                    command = input[..spaceIndex].Trim();
                    argument = input[spaceIndex..].Trim();
                }

                switch (command)
                {
                    case GoCommand:
                        var flights = flightQuery.RunQuery();
                        if (flights.Any())
                        {
                            var average = flights.Average(fl => fl.PaidFair);
                            var min = flights.Min(fl => fl.PaidFair);
                            var max = flights.Max(fl => fl.PaidFair);
                            Console.WriteLine($"Results: Count={flights.Count}, Avg={average:N2}, Min={min:N2}, Max={max:N2}");
                        }
                        else
                        {
                            Console.WriteLine("No matching flights found");
                        }
                        break;

                    case ClearCommand:
                        flightQuery.ClearFilters();
                        break;

                    case ClassCommand:
                        flightQuery.AddFilter(FilterCriteriaType.Class, argument);
                        break;

                    case OriginCommand:
                        flightQuery.AddFilter(FilterCriteriaType.Origin, argument);
                        break;

                    case DestinationCommand:
                        flightQuery.AddFilter(FilterCriteriaType.Destination, argument);
                        break;
                }
            } while (input != string.Empty);
        }
    }
}
