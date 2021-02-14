using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Chapter04.Activities.Activity01
{
    internal interface IFlightLoader
    {
        IList<Flight> Import(string filePath);

        IList<Flight> Download(string url, string filePath);
    }

    internal class FlightLoader : IFlightLoader
    {
        private static class ImportFieldIndex
        {
            public const int Agency = 0;
            public const int PaidFair = 1;
            public const int TripType = 2;
            public const int RoutingType = 3;
            public const int TicketClass = 4; 
            public const int DepartureDate = 5;
            public const int Origin = 6;
            public const int Destination = 7;
            public const int DestinationCountry = 8;
            public const int Carrier = 9;
        }

        public IList<Flight> Import(string filePath)
        {
            var flights = new List<Flight>();

            // Skip the header line
            foreach (var line in File.ReadLines(filePath)
                .Skip(1)
                .Where(ln => !string.IsNullOrWhiteSpace(ln)))
            {
                var fields = line.Split(",");

                if (fields.Length < ImportFieldIndex.Carrier ||
                    string.IsNullOrEmpty(fields[ImportFieldIndex.Agency]))
                    continue;

                double.TryParse(fields[ImportFieldIndex.PaidFair], out double paidFair);

                var flight = new Flight(
                    fields[ImportFieldIndex.Agency],
                    paidFair,
                    fields[ImportFieldIndex.TripType],
                    fields[ImportFieldIndex.RoutingType],
                    fields[ImportFieldIndex.TicketClass],
                    fields[ImportFieldIndex.DepartureDate],
                    fields[ImportFieldIndex.Origin],
                    fields[ImportFieldIndex.Destination],
                    fields[ImportFieldIndex.DestinationCountry],
                    fields[ImportFieldIndex.Carrier]);

                flights.Add(flight);
                Console.Write(".");
            }

            return flights;
        }

        public IList<Flight> Download(string url, string filePath)
        {
            using var client = new WebClient();
            client.DownloadFile(url, filePath);

            return Import(filePath);
        }
    }
}
