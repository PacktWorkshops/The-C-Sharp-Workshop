using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter02.Examples.Generics.CustomlistTesting
{
    [TestClass]
    public class CustomListOfIntTest : CustomListTests<int>
    {
        protected override int First => 1;
        protected override int Second => 2;
    }
}