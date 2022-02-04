using System.Diagnostics.CodeAnalysis;

namespace Chapter02.Examples.Encapsulation
{
    [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
    [SuppressMessage("ReSharper", "ArgumentsStyleStringLiteral")]
    public static class Demo
    {
        public static void Run()
        {
            var sparky = new Dog("Sparky");
            var ricky = new Dog("Ricky");
            ricky.Owner = "Tom";
            sparky.Bark();
            ricky.Sit();
        }
    }
}
