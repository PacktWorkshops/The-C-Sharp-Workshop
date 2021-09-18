using System.Collections.Generic;
using System.Threading.Tasks;
using Chapter08.Exercises.Exercise02;
using Chapter08.Exercises.Exercise02.Models;

namespace Chapter08.Activities.Activity01
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
