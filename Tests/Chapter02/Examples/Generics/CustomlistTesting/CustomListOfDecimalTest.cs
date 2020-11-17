using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter02.Examples.Generics.CustomlistTesting
{
    [TestClass]
    public class CustomListOfDecimalTest : CustomListTests<decimal>
    {
        protected override decimal First => 1m;
        protected override decimal Second => 2m;
    }
}