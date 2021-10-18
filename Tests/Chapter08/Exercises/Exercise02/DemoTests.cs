using System;
using System.Threading.Tasks;
using Chapter08.Exercises.Exercise02;

namespace Tests.Chapter08.Exercises.Exercise02
{
    public static class DemoTests
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
