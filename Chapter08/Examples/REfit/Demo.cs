using System;
using Refit;

namespace Chapter08.Examples.REfit
{
    public static class Demo
    {
        public static void Run()
        {
            var client = RestService.For<IStarWarsClient>("https://swapi.dev/api/");
            var filmsResponse = client.GetFilms().Result;
            var films = filmsResponse.Data;
            foreach (var film in films)
            {
                Console.WriteLine($"{film.ReleaseDate} {film.Title}");
            }
        }
    }
}
