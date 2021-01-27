using System;
using Chapter02.Examples.Encapsulation;

namespace Chapter02.Examples.ValueAndRef
{
    public static class Demo
    {
        public static void Run()
        {
            int a = 2;
            // 2
            Console.WriteLine(a);
            SetTo5(a);
            // a is still 2
            Console.WriteLine(a);
            
            Dog dog = new Dog("speedy");
            Console.WriteLine(dog.Owner);
            ResetOwner(dog);
            // Owner is "None"- changes remain
            Console.WriteLine(dog.Owner);
            // dog is unchanged
            Recreate(dog);
            // dog is recreated
            RecreateRef(ref dog);
        }

        private static void SetTo5(int number)
        {
            number = 5;
        }

        private static void ResetOwner(Dog dog)
        {
            dog.Owner = "None";
        }

        private static void Recreate(Dog dog)
        {
            dog = new Dog("Recreated");
        }

        private static void RecreateRef(ref Dog dog)
        {
            dog = new Dog("Recreated");
        }
    }
}
