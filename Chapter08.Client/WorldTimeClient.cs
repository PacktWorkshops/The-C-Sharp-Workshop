using Chapter08.Client.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Chapter08.Client
{
    public class WorldTimeClient
    {
        private readonly HttpClient _client;

        public WorldTimeClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<DateTimeResponse> GetCurrentDateTime() => await _client.GetFromJsonAsync<DateTimeResponse>("ip");
    }
}
