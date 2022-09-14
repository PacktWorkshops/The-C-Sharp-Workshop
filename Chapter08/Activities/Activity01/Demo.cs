using System;
using System.Threading.Tasks;

namespace Chapter08.Activities.Activity01
{
    public static class Demo
    {
        public static async Task Run()
        {
            using var client = new StarWarsClient();
            var filmsResponse = await client.GetFilms();
            var films = filmsResponse.Results;
            foreach (var film in films)
            {
                Console.WriteLine($"{film.Release_Date} {film.Title}");
            }
        }
    }
}
