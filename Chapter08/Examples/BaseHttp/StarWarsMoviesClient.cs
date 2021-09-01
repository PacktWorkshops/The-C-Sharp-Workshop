using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Chapter08.Exercises.Exercise02.Models;
using Newtonsoft.Json;

namespace Chapter08.Examples.BaseHttp
{
    public class StarWarsClient : BaseHttpClient
    {
        public StarWarsClient():base("https://swapi.dev/api/")
        {
        }

        public async Task<ApiResult<IEnumerable<Film>>> GetFilms()
        {
            var request = CreateGetRequest("films");
            var films = await SendGetManyRequest<Film>(request);

            return films;
        }
    }
}
