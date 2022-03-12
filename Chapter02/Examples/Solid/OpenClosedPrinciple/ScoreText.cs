using System;

namespace Chapter02.Examples.Solid.OpenClosedPrinciple
{
    class Bad
    {
        interface IMovableDamageable
        {
            void Move(Location location);
            float Hp { get; set; }
        }

        class House : IMovableDamageable
        {
            public float Hp { get; set; }

            public void Move(Location location)
            {
                throw new NotSupportedException();
            }
        }

        class ScoreText : IMovableDamageable
        {
            public float Hp
            {
                get => throw new NotSupportedException();
                set => throw new NotSupportedException();
            }

            public void Move(Location location)
            {
                Console.WriteLine($"Moving to {location}");
            }
        }

        public class Location
        {
        }
    }

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

}
