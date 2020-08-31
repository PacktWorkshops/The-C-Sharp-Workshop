using System;

namespace Chapter3
{
    public class Greeks
    {
        public double? Delta { get; set; }
        public double? Gamma { get; set; }
    }

    public class Prices
    {
        public double? Close { get; set; }
    }

    public class FieldComparison<T>
    {
        private readonly Func<T, double?> _selector;

        public FieldComparison(Func<T, double?> selector)
        {
            _selector = selector;
        }

        public double? Yesterday { get; private set; }

        public double? Today { get; private set; }

        public double? Difference { get; private set; }

        public void DoComparison(T yes, T tod)
        {
            Yesterday = _selector(yes);
            Today = _selector(tod);

            Difference = Yesterday != null && Today != null
                ? Yesterday - Today
                : null;
        }
    }

    public class ModelDifferences
    {
        public ModelDifferences()
        {
            Delta = new FieldComparison<Greeks>(data => data.Delta);
            Gamma = new FieldComparison<Greeks>(data => data.Gamma * 100D);
            Close = new FieldComparison<Prices>(data => data.Close);
        }

        public FieldComparison<Greeks> Delta { get; }
        public FieldComparison<Greeks> Gamma { get; }
        public FieldComparison<Prices> Close { get; }

        public void Compare(Greeks greeksYesterday, Greeks greeksToday,
            Prices pricesYesterday, Prices pricesToday)
        {
            Delta.DoComparison(greeksYesterday, greeksToday);
            Gamma.DoComparison(greeksYesterday, greeksToday);
            Close.DoComparison(pricesYesterday, pricesToday);
        }
    }
}
