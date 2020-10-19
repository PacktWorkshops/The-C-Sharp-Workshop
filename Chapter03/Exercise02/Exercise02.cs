using System;
using System.Globalization;

namespace Chapter03.Exercise02
{
    public class Car
    {
        public double Distance { get; set; }
        public double FuelUsed { get; set; }
    }

    public class Comparison
    {
        private readonly Func<Car, double> _valueSelector;

        public Comparison(Func<Car, double> valueSelector)
        {
            _valueSelector = valueSelector;
        }

        public double Yesterday { get; private set; }

        public double Today { get; private set; }

        public double Difference { get; private set; }

        public void Compare(Car yesterday, Car today)
        {
            Yesterday = _valueSelector(yesterday);
            Today = _valueSelector(today);
            Difference = Yesterday - Today;
        }
    }

    public class JourneyComparer
    {
        public JourneyComparer()
        {
            Distance = new Comparison(GetCarDistance);
            FuelUsed = new Comparison(CarCarFuelUsed);
            FuelEconomy = new Comparison(CarCarFuelEconomy);
        }

        private static double GetCarDistance(Car car)
        {
            return car.Distance;
        }

        private static double CarCarFuelUsed(Car car)
        {
            return car.FuelUsed;
        }

        private static double CarCarFuelEconomy(Car car)
        {
            return car.Distance / car.FuelUsed;
        }

        public Comparison Distance { get; }
        public Comparison FuelUsed { get; }
        public Comparison FuelEconomy { get; }

        public void Compare(Car yesterday, Car today)
        {
            Distance.Compare(yesterday, today);
            FuelUsed.Compare(yesterday, today);
            FuelEconomy.Compare(yesterday, today);
        }
    }

    public class Program
    {
        public static void Main()
        {
            var random = new Random();
            string input;
            do
            {
                Console.Write("Yesterday's distance");
                input = Console.ReadLine();
                double.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out var distanceYesterday);

                var carYesterday = new Car
                {
                    Distance = distanceYesterday,
                    FuelUsed = random.NextDouble() * 10D
                };

                Console.Write("Today's distance:");
                input = Console.ReadLine();
                double.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out var distanceToday);

                var carToday = new Car
                {
                    Distance = distanceToday,
                    FuelUsed = random.NextDouble() * 10D
                };

                var comparer = new JourneyComparer();
                comparer.Compare(carYesterday, carToday);

                Console.WriteLine("Journey Details    Distance       Fuel Used");
                Console.WriteLine($"Yesterday:    {carYesterday.Distance}\t{carYesterday.FuelUsed}");
                Console.WriteLine($"Today:        {carToday.Distance}    \t{carToday.FuelUsed}");
                Console.WriteLine("================================================================");
                Console.WriteLine($"Comparison:   {comparer.Distance}    \t{comparer.FuelUsed}   ");
                Console.WriteLine($"Fuel Economy={comparer.FuelEconomy}");
            } 
            while (!string.IsNullOrEmpty(input));

        }
    }
}
