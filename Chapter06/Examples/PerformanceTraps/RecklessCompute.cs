using System.Linq;
using Chapter06.Examples.Custom;
using Chapter06.Examples.GlobalFactory2020;

namespace Chapter06.Examples.PerformanceTraps
{
    public static class RecklessCompute
    {
        /// <summary>
        /// Key difference: format multiple times
        /// </summary>
        public static void Slow()
        {
            var db = new globalfactory2020Context();

            var filtered = db.Products
                .Where(p => p.Name.Trim() == DataSeeding.TestProduct2NameNotPadded)
                .ToList();

            db.Dispose();
        }

        /// <summary>
        /// Key difference: format once
        /// </summary>
        public static void Fast()
        {
            var db = new globalfactory2020Context();

            // When using char or nchar- you will have a padded field
            // In order to find it, you will need to to make both sides:
            // filter and the column- to be of the same format
            // instead of trimming every column (n)
            // format the filter to match the formatting of a column (1)
            var filter = DataSeeding.TestProduct2NameNotPadded.PadLeft(13);
            var filtered = db.Products
                .Where(p => p.Name == filter)
                .ToList();

            db.Dispose();
        }
    }
}
