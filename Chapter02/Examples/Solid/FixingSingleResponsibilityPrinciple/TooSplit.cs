using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter02.Examples.SOLID.FixingS
{
    public static class TooSplit
    {
        public class Merchandise
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            // VAT on top in %
            public decimal Vat { get; set; }
        }

        public static class PriceAfterTaxesCalculator
        {
            public static decimal CalculatePriceAfterTaxes(decimal price, decimal vat)
            {
                return price * (1 + vat / 100);
            }
        }
    }
}
