using System;
using System.Globalization;

namespace Chapter03.Exercise02
{
    public class Car
    {
        public double Distance { get; set; }
        public double JourneyTime { get; set; }
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

        public void Compare(Car yesterdayCar, Car todayCar)
        {
            Yesterday = _valueSelector(yesterdayCar);
            Today = _valueSelector(todayCar);
            Difference = Yesterday - Today;
        }
    }

    public class JourneyComparer
    {
        public JourneyComparer()
        {
            Distance = new Comparison(GetCarDistance);
            JourneyTime = new Comparison(GetCarJourneyTime);
            AverageSpeed = new Comparison(GetCarAverageSpeed);
        }

        public Comparison Distance { get; }
        public Comparison JourneyTime { get; }
        public Comparison AverageSpeed { get; }

        private static double GetCarDistance(Car car)
        {
            return car.Distance;
        }

        private static double GetCarJourneyTime(Car car)
        {
            return car.JourneyTime;
        }

        private static double GetCarAverageSpeed(Car car)
        {
            return car.Distance / car.JourneyTime;
        }

        
        public void Compare(Car yesterday, Car today)
        {
            Distance.Compare(yesterday, today);
            JourneyTime.Compare(yesterday, today);
            AverageSpeed.Compare(yesterday, today);
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
                Console.Write("Yesterday's distance: ");
                input = Console.ReadLine();
                double.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out var distanceYesterday);

                var carYesterday = new Car
                {
                    Distance = distanceYesterday,
                    JourneyTime = random.NextDouble() * 10D
                };

                Console.Write("    Today's distance: ");
                input = Console.ReadLine();
                double.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out var distanceToday);

                var carToday = new Car
                {
                    Distance = distanceToday,
                    JourneyTime = random.NextDouble() * 10D
                };

                var comparer = new JourneyComparer();
                comparer.Compare(carYesterday, carToday);

                Console.WriteLine();
                Console.WriteLine("Journey Details   Distance\tTime\tAvg Speed");
                Console.WriteLine("-------------------------------------------------");

                Console.Write($"Yesterday         {comparer.Distance.Yesterday:N0}   \t");
                Console.WriteLine($"{comparer.JourneyTime.Yesterday:N0}\t{comparer.AverageSpeed.Yesterday:N0}");

                Console.Write($"Today             {comparer.Distance.Today:N0}     \t"); 
                Console.WriteLine($"{comparer.JourneyTime.Today:N0}\t{comparer.AverageSpeed.Today:N0}");

                Console.WriteLine("=================================================");
                Console.Write($"Difference        {comparer.Distance.Difference:N0}     \t");
                Console.WriteLine($"{comparer.JourneyTime.Difference:N0}\t{comparer.AverageSpeed.Difference:N0}");
                Console.WriteLine("=================================================");
            } 
            while (!string.IsNullOrEmpty(input));

        }
    }
}
