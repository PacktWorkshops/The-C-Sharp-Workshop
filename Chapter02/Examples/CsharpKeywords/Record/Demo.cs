using System;
using System.Runtime.InteropServices;

namespace Chapter02.Examples.CsharpKeywords.Record
{
    public static class Demo
    {
        public static void Run()
        {
            Console.WriteLine("-----Class----");
            DemoClass();
            Console.WriteLine("-----Struct----");
            DemoStruct();
            Console.WriteLine("-----Record----");
            DemoRecord();
            Console.WriteLine("---------------");
        }

        private static void DemoClass()
        {
            var movie1 = new MovieClass(
                "Star Wars: Episode I – The Phantom Menace",
                "George Lucas",
                "Rick McCallum",
                new DateTime(1999, 5, 15));

            var movie2 = new MovieClass(
                "Star Wars: Episode I – The Phantom Menace",
                "George Lucas",
                "Rick McCallum",
                new DateTime(1999, 5, 15));

            Console.WriteLine(movie1);
            Console.WriteLine(movie1.Equals(movie2));
            Console.WriteLine(movie1 == movie2);

            SetDescription(movie1);
            Console.WriteLine(movie1.Description);
        }

        private static void DemoRecord()
        {
            var movie1 = new MovieRecord(
                "Star Wars: Episode I – The Phantom Menace",
                "George Lucas",
                "Rick McCallum",
                new DateTime(1999, 5, 15));

            var movie2 = new MovieRecord(
                "Star Wars: Episode I – The Phantom Menace",
                "George Lucas",
                "Rick McCallum",
                new DateTime(1999, 5, 15));

            Console.WriteLine(movie1);
            Console.WriteLine(movie1.Equals(movie2));
            Console.WriteLine(movie1 == movie2);

            SetDescription(movie1);
            Console.WriteLine(movie1.Description);

            var movie3 = movie2 with { Description = "Records can do that?" };
            movie2.Description = "Changing original";
            Console.WriteLine(movie3);
        }

        private static void DemoStruct()
        {
            var movie1 = new MovieStruct(
                "Star Wars: Episode I – The Phantom Menace",
                "George Lucas",
                "Rick McCallum",
                new DateTime(1999, 5, 15));

            var movie2 = new MovieStruct(
                "Star Wars: Episode I – The Phantom Menace",
                "George Lucas",
                "Rick McCallum",
                new DateTime(1999, 5, 15));

            Console.WriteLine(movie1);
            Console.WriteLine(movie1.Equals(movie2));
            // Does not compile
            //Console.WriteLine(movie1 == movie2);

            SetDescription(movie1);
            Console.WriteLine(movie1.Description);
        }

        private static void SetDescription(MovieClass movie)
        {
            movie.Description = "Good movie";
        }

        private static void SetDescription(MovieRecord movie)
        {
            movie.Description = "Good movie";
        }

        private static void SetDescription(MovieStruct movie)
        {
            movie.Description = "Good movie";
        }
    }
}
