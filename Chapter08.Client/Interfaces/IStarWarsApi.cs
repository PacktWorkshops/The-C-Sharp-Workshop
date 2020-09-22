using Chapter08.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chapter08.Client.Interfaces
{
    public interface IStarWarsApi
    {
        [Get("/people/")]
        Task<Response<List<Person>>> GetPeopleAsync();

        [Get("/planets/")]
        Task<Response<List<Planet>>> GetPlanetsAsync();
    }
}
