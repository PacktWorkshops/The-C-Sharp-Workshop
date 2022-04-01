namespace Chapter02.Examples.Solid.DependencyInjectionPrinciple
{
    public static class DependencyInjection
    {
        public static class Constructor
        {
            class Bar
            {
                private readonly IBartender _bartender;

                public Bar(IBartender bartender)
                {
                    _bartender = bartender;
                }
            }

            public static void Demo()
            {
                var foo = new Bar(new Bartender());
            }
        }

        public static class Method
        {
            class Bar
            {
                public void ServeDrinks(IBartender bartender)
                {
                    // serve drinks using bartender
                }
            }

            public static void Demo()
            {
                var bar = new Bar();
                bar.ServeDrinks(new Bartender());
            }
        }

        public static class Property
        {
            class Bar
            {
                public IBartender Bartender { get; set; }
            }

            public static void Demo()
            {
                var bar = new Bar();
                bar.Bartender = new Bartender();
            }

        }
    }
}
