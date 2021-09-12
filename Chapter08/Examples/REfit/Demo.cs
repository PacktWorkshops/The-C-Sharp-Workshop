using System;
using System.Threading.Tasks;
using Refit;

namespace Chapter08.Examples.REfit
{
    public static class Demo
    {
        public static async Task Run()
        {
            var client = RestService.For<IStarWarsClient>("https://swapi.dev/api/");
            var filmsResponse = await client.GetFilms();
            var films = filmsResponse.Data;
            foreach (var film in films)
            {
                Console.WriteLine($"{film.ReleaseDate} {film.Title}");
            }
        }
    }
}
