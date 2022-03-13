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

                // use bar in other methods.
            }

            public static void Demo()
            {
                var foo = new Bar(new DependencyInjectionPrinciple.Bartender());
            }
        }

        public static class Method
        {
            class Bar
            {
                public void Foobar(IBartender bartender)
                {
                    // do something with Bar
                }
            }

            public static void Demo()
            {
                var foo = new Bar();
                foo.Foobar(new Bartender());
            }
        }

        public static class Property
        {
            class Bar
            {
                public IBartender Bartender { get; set; }
                // use bar in other methods.
            }

            public static void Demo()
            {
                var foo = new Bar();
                foo.Bartender = new Bartender();
            }

        }
    }
}
