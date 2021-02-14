using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter04.Activities.Activity01
{
    internal class FlightQuery
    {
        private readonly List<Flight> _flights = new();
        private readonly List<FilterCriteria> _filters = new();
        private readonly IFlightLoader _loader;

        public FlightQuery(IFlightLoader loader)
        {
            _loader = loader;
        }

        public void Import(string path)
        {
            _flights.Clear();
            _flights.AddRange(_loader.Import(path));
        }

        public void Download(string url, string filePath)
        {
            _flights.Clear();
            _flights.AddRange(_loader.Download(url, filePath));
        }

        public int Count => _flights.Count;

        public void AddFilter(FilterCriteriaType filter, string operand)
        {
            _filters.Add(new FilterCriteria(filter, operand));
            Console.WriteLine($"Added filter: {filter}={operand}");
        }

        public void ClearFilters()
        {
            _filters.Clear();
            Console.WriteLine("Cleared filters");
        }

        public IList<Flight> RunQuery()
        {
            var comparer = StringComparer.InvariantCultureIgnoreCase;

            var query = _flights.Select(f => f);

            var filterClasses = GetFiltersByType(FilterCriteriaType.Class);
            if (filterClasses.Any())
            {
                query = query.Where(flt => filterClasses.Contains(flt.TicketClass, comparer));
                Console.WriteLine($"Classes: {FormatFilters(filterClasses)}");
            }

            var filterDestinations = GetFiltersByType(FilterCriteriaType.Destination);
            if (filterDestinations.Any())
            {
                query = query.Where(flt => filterDestinations.Contains(flt.Destination, comparer));
                Console.WriteLine($"Destinations: {FormatFilters(filterDestinations)}");
            }

            var filterOrigins = GetFiltersByType(FilterCriteriaType.Origin);
            if (filterOrigins.Any())
            {
                query = query.Where(flt => filterOrigins.Contains(flt.Origin, comparer));
                Console.WriteLine($"Origins: {FormatFilters(filterOrigins)}");
            }

            return query.ToList();
        }

        private IList<string> GetFiltersByType(FilterCriteriaType filter)
            => _filters
                .Where(f => f.Filter == filter)
                .Select(f => f.Operand)
                .ToList();

        private string FormatFilters(IEnumerable<string> filterValues)
            => string.Join(" OR ", filterValues);
    }
}
