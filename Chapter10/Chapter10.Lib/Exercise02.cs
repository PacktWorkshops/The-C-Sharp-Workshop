using System.Linq;
using System.Collections.Generic;

namespace Chapter10.Lib
{
    public static class DeliveryFilters
    {
        public static IEnumerable<Package> GetSortedMiddleWeightPackages(
             IEnumerable<Package> items, int top)
        {
            return items
                .Where(IsMiddleWeightPackage)
                .OrderByDescending(p => p.Distance)
                .Take(top);

            static bool IsMiddleWeightPackage(Package package)
                => package.Weight is (>= 10 and <= 20);
        }

        public static Package[] GetLastTwoPackages(Package[] items)
        {
            return items[^2..^0];
        }

    }
}
