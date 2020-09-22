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

        [Get("/people/{id}/")]
        Task<Person> GetPersonAsync(int id);

        [Get("/planets/")]
        Task<Response<List<Planet>>> GetPlanetsAsync();

        [Get("/films/")]
        Task<Response<List<Film>>> GetFilmsAsync();

        [Get("/films/{id}/")]
        Task<Film> GetFilmAsync(int id);
    }
}
