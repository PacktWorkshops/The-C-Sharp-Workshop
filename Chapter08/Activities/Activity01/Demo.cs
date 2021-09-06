using System;

namespace Chapter08.Activities.Activity01
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
