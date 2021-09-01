using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter08.Exercises.Exercise02
{
    public static class Demo
    {
        public static void Run()
        {
            var client = new StarWarsClient();
            var filmsResponse = client.GetFilms().Result;
            var films = filmsResponse.Data;
            foreach (var film in films)
            {
                Console.WriteLine($"{film.ReleaseDate} {film.Title}");
            }
        }
    }
}
