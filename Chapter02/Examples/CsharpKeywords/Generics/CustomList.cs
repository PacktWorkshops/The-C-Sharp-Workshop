using System;

namespace Chapter02.Examples.CsharpKeywords.Generics
{
    public class CustomList<T>
    {
        private T[] _items;

        public int Count => _items.Length;

        public CustomList()
        {
            _items = new T[0];
        }

        public CustomList(T[] items)
        {
            _items = new T[items.Length];
            Array.Copy(items, _items, items.Length);
        }

        public void Add(T item)
        {
            var expanded = new T[_items.Length+1];
            Array.Copy(_items, expanded, _items.Length);
            expanded[^1] = item;
            _items = expanded;
        }

        public T GetAtIndex(int index)
        {
            return _items[index];
        }

        public void RemoveAtIndex(int index)
        {
            if (index >= _items.Length)
            {
                throw new IndexOutOfRangeException($"{index} is more than last index {_items.Length-1}");
            }

            var shrunk = new T[_items.Length - 1];
            for (int i = 0; i < _items.Length; i++)
            {
                if (i == index)
                {
                    continue;
                }

                shrunk[i] = _items[i];
            }

            _items = shrunk;
        }
    }
}
