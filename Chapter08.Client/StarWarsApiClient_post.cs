using Chapter08.Models;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Chapter08
{
    /// <summary>
    /// this partial class has http post methods
    /// </summary>
    public partial class StarWarsApiClient
    {
        public async Task CreatePerson(Person person) => await _client.PostAsJsonAsync(GetUrl("people/"), person);
    }
}
