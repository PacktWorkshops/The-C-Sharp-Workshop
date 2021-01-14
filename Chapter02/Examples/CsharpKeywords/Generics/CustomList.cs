using System;

namespace Chapter02.Examples.CsharpKeywords.Generics
{
    public class CustomList<T>
    {
        public T[] Items { get; set; }

        public int Count => Items.Length;

        public CustomList()
        {
            Items = new T[0];
        }

        public CustomList(T[] items)
        {
            Items = new T[items.Length];
            Array.Copy(items, Items, items.Length);
        }

        public void Add(T item)
        {
            var expanded = new T[Items.Length+1];
            Array.Copy(Items, expanded, Items.Length);
            expanded[^1] = item;
            Items = expanded;
        }

        public void RemoveAtIndex(int index)
        {
            if (index >= Items.Length)
            {
                throw new IndexOutOfRangeException($"{index} is more than last index {Items.Length-1}");
            }

            var shrunk = new T[Items.Length - 1];
            for (int i = 0; i < Items.Length; i++)
            {
                if (i == index)
                {
                    continue;
                }

                shrunk[i] = Items[i];
            }

            Items = shrunk;
        }
    }
}
