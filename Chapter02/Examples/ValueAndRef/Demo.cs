using Chapter02.Examples.Encapsulation;

namespace Chapter02.Examples.ValueAndRef
{
    public static class Demo
    {
        public static void Run()
        {
            int a = 2;
            // a is still 2
            SetTo5(a);
            
            Dog dog = new Dog("speedy");
            // Owner is ""- changes remain
            ResetOwner(dog);
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
            dog.Owner = "";
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
