using System;

namespace Chapter10.Lib
{
    public record Envelope
    {
        public Envelope(int distance) 
            => (Distance) = (distance);

        public int Distance { get; }
    }

    public record Package
    {
        public Package(int distance, int weight) 
            => (Distance, Weight) = (distance, weight);

        public int Distance { get; }
        public int Weight { get; }
    }

    public record Meal
    {
        public Meal(bool isHot) 
            => (IsHot) = (isHot);

        public bool IsHot { get; }
    }

    public static class DeliveryCalculator
    {
        public static double GetCost(object item)
            => item switch
            {
                Envelope e 
                    => e.Distance * 1,

                Package p when p.Weight < 10 
                    => p.Distance * 2,

                Package p when p.Weight >= 10 
                    => p.Distance * 3,

                Meal m when !m.IsHot 
                    => 4,

                Meal m when m.IsHot 
                    => 6,

                { }             
                    => throw new ArgumentException(),

                null
                    => throw new ArgumentNullException()
            };
    }
}
