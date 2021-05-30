using System;

namespace Chapter02.Exercises.Exercise01
{
    public static class Solution
    {
        public static void Main()
        {
            Book book1 = new Book();
            Book book2 = new Book();

            Print(book1);
            Print(book2);
        }

        private static void Print(Book book)
        {
            int test = 1;
            Console.WriteLine($"Author: {book.Author}, " +
                              $"Title: {book.Title}, " +
                              $"Publisher: {book.Publisher}, " +
                              $"Description: {book.Description}.");
        }
    }
}
