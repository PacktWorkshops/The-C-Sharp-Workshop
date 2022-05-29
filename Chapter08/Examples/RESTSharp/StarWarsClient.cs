
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Chapter08.Examples.RestSharp
{
    public class StarWarsClient
    {
        private readonly RestClient _client;

        public StarWarsClient()
        {
            _client = new RestClient("https://swapi.dev/api/");
            _client.UseSerializer(() => new JsonNetSerializer());
        }

        public async Task<ApiResult<IEnumerable<Film>>> GetFilms()
        {
            var request = new RestRequest("films");
            var films = await _client.GetAsync<ApiResult<IEnumerable<Film>>>(request);

            return films;
        }
    }
}
