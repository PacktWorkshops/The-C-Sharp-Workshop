namespace Chapter02.Examples.Solid.FixingSingleResponsibilityPrinciple
{
    public class Merchandise
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        // VAT on top in %
        public decimal Vat { get; set; }
        public decimal PriceAfterTaxes => Price * (1 + Vat / 100);
    }
}