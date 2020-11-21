using System;

namespace Chapter10.Exercise01
{
    public record Envelope
    {
        public Envelope(int distance) => (Distance) = (distance);

        public int Distance { get; }
    }

    public record Package
    {
        public Package(int distance, int weight) => (Distance, Weight) = (distance, weight);

        public int Distance { get; }

        public int Weight { get; }
    }

    public record Meal
    {
        public Package(int distance, bool isHot) => (Distance, IsHot) = (distance, isHot);

        public int Distance { get; }

        public bool IsHot { get; }
    }

    public class DeliveryCalculator
    {
        public double GetCost(object item)
            => item switch
            {
                Envelope e => e.Distance * 1,
                Package p when p.Distance < 1   => p.Distance * 2,
                Package p when p.Distance >= 1  => p.Distance * 2.5,
                Meal m when !m.IsHot => 4,
                Meal m when m.IsHot => 6,
    //            { }             => throw new ArgumentException(message: "Not a known vehicle type", paramName: nameof(vehicle)),
    //          null            => throw new ArgumentNullException(nameof(vehicle))
            };
    }
}
