using System;
using System.Threading.Tasks;

namespace Chapter08.Examples.RESTSharp
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
