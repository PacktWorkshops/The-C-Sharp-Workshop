using System;
using Chapter02.Examples.CsharpKeywords.Generics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Chapter02.Examples.Generics.CustomlistTesting
{
    public abstract class CustomListTests<T>
    {
        protected abstract T First { get; }
        protected abstract T Second { get; }

        [TestMethod]
        public void New_CreatesEmptyList()
        {
            var list = new CustomList<T>();

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void New_WhenArray_CreateListWithArrayElements()
        {
            T[] array = {First, Second};
            var list = new CustomList<T>(array);

            Assert.AreEqual(First, list.GetAtIndex(0));
            Assert.AreEqual(Second, list.GetAtIndex(1));
        }

        [TestMethod]
        public void Add_AddsElementInTheEnd()
        {
            var list = new CustomList<T>();

            list.Add(First);

            Assert.AreEqual(First, list.GetAtIndex(0));
        }

        [TestMethod]
        public void RemoveAtIndex_When_IndexInBounds_RemovesElementsAtIndex()
        {
            T[] array = { First };
            var list = new CustomList<T>(array);

            list.RemoveAtIndex(0);

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void RemoveAtIndex_When_IndexOutOfBounds_Throws_IndexOutOfRangeException()
        {
            var list = new CustomList<T>();

            void Remove() => list.RemoveAtIndex(0);

            Assert.ThrowsException<IndexOutOfRangeException>(Remove);
        }
    }
}
