using System;

namespace Chapter02.Examples.Solid.OpenClosedPrinciple;

class Good
{
    interface IMovable
    {
        void Move(Location location);
    }

    interface IDamageable
    {
        float Hp { get; set; }
    }

    class House : IDamageable
    {
        public float Hp { get; set; }
    }

    class ScoreText : IMovable
    {
        public void Move(Location location)
        {
            Console.WriteLine($"Moving to {location}");
        }
    }

    public class Location
    {
    }
}