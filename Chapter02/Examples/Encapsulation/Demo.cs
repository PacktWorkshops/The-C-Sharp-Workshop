namespace Chapter02.Examples.Encapsulation
{
    public static class Demo
    {
        public static void Run()
        {
            var sparky = new Dog("Sparky");
            var ricky = new Dog("Ricky");
            sparky.Bark();
            ricky.Sit();
        }
    }
}
