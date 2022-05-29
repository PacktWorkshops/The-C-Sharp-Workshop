using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Chapter08.Exercises.Exercise02
{
    public class StarWarsClient
    {
        private readonly HttpClient _client;

        public StarWarsClient()
        {
            _client = new HttpClient {BaseAddress = new Uri("https://swapi.dev/api/")};
        }

        public async Task<ApiResult<IEnumerable<Film>>> GetFilms()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, new Uri("films", UriKind.Relative));
            var response = await _client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            var content = await response.Content.ReadAsStringAsync();
            var films = JsonConvert.DeserializeObject<ApiResult<IEnumerable<Film>>>(content);

            return films;
        }
    }
}
