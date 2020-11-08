namespace Chapter02.Examples
{
    public class Demo
    {
        public static void Run()
        {
            DemoDog();
        }

        private static void DemoDog()
        {
            var sparky = new Dog("Sparky");
            var ricky = new Dog("Ricky");
            sparky.Bark();
            ricky.Sit();
        }
    }
}