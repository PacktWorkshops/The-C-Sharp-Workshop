using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter02.Examples.SOLID
{
    public static class DependencyInjection
    {
        public static class Constructor
        {
            class Foo
            {
                private readonly IBar _bar;

                public Foo(IBar bar)
                {
                    _bar = bar;
                }

                // use bar in other methods.
            }

            public static void Demo()
            {
                var foo = new Foo(new Bar());
            }
        }

        public static class Method
        {
            class Foo
            {
                public void Foobar(IBar bar)
                {
                    // do something with Bar
                }
            }

            public static void Demo()
            {
                var foo = new Foo();
                foo.Foobar(new Bar());
            }
        }

        public static class Property
        {
            class Foo
            {
                public IBar Bar { get; set; }
                // use bar in other methods.
            }

            public static void Demo()
            {
                var foo = new Foo();
                foo.Bar = new Bar();
            }

        }
    }

    interface IBar { }
    class Bar : IBar { }
}
