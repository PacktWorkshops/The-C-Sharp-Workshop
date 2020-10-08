using Chapter08.Models;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Chapter08
{
    /// <summary>
    /// this partial class has http post methods, meant for running locally only
    /// because swapi.dev is read-only and doesn't allow posting
    /// </summary>
    public partial class StarWarsApiClient
    {
        public async Task CreatePerson(Person person) => await _client.PostAsJsonAsync(GetUrl("people/"), person);
    }
}
