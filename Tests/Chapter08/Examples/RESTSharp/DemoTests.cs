using System;
using System.Threading.Tasks;
using Chapter08.Examples.RESTSharp;

namespace Tests.Chapter08.Examples.RESTSharp
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
