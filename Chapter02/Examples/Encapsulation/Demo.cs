using System.Diagnostics.CodeAnalysis;

namespace Chapter02.Examples.Encapsulation
{
    public static class Demo
    {
        public static void Run()
        {
            var dog = new Dog();
            var sparky = new Dog("Sparky");
            var ricky = new Dog("Ricky");
            ricky.Owner = "Tom";
            sparky.Bark();
            ricky.Sit();
        }
    }
}
