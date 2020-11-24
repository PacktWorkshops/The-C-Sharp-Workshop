using Chapter02.Examples.Encapsulation;

namespace Chapter02.Examples.CsharpKeywords.NullOperators
{
    public static class Demo
    {
        public static void Run()
        {
            var componentB = new ComponentB(new ComponentA());

            var dog1 = new Dog("Sparky");
            if (dog1.Owner != null)
            {
                bool ownerNameStartsWithA = dog1.Owner.StartsWith('A');
            }
            dog1.Owner?.StartsWith('A');

            string description;
            if (dog1.Owner == null)
            {
                description = dog1.Name;
            }
            else
            {
                description = $"{dog1.Name}, dog of {dog1.Owner}";
            }

            description = dog1.Owner == null
                ? dog1.Name
                : $"{dog1.Name}, dog of {dog1.Owner}";

            var dog2 = new Dog("Speedy");

            if (dog1.Owner != null)
            {
                dog2.Owner = dog1.Owner;
            }

            dog1.Owner ??= dog2.Owner;
        }
    }
}
