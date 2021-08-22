using System;

namespace Chapter02.Exercises.Exercise01
{
    public static class Solution
    {
        public static void Main()
        {
            Book book1 = new Book();
            book1.Author = "New Writer";
            book1.Title = "First Book";
            book1.Publisher = "Publisher 1";

            Book book2 = new Book();
            book2.Author = "New Writer";
            book2.Title = "Second Book";
            book2.Publisher = "Publisher 2";
            book2.Description = "Interesting read";

            Print(book1);
            Print(book2);
        }

        private static void Print(Book book)
        {
            Console.WriteLine($"Author: {book.Author}, " +
                              $"Title: {book.Title}, " +
                              $"Publisher: {book.Publisher}, " +
                              $"Description: {book.Description}.");
        }
    }
}
