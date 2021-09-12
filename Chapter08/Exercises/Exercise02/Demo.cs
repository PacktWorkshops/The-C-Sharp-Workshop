using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chapter08.Exercises.Exercise02
{
    public static class Demo
    {
        public static async Task Run()
        {
            var client = new StarWarsClient();
            var filmsResponse = await client.GetFilms();
            var films = filmsResponse.Data;
            foreach (var film in films)
            {
                Console.WriteLine($"{film.ReleaseDate} {film.Title}");
            }
        }
    }
}
