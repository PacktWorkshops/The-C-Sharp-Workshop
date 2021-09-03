using System;

namespace Chapter08.Examples.BaseHttp
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
