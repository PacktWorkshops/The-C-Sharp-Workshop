using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter02.Examples.Generics.CustomlistTesting
{
    [TestClass]
    public class CustomListOfDummy: CustomListTests<Dummy>
    {
        protected override Dummy First => new Dummy(1);
        protected override Dummy Second => new Dummy(2);
    }
}