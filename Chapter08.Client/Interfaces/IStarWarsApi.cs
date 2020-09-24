using Chapter08.Client.Models;
//using Chapter08.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
//using Planet = Chapter08.Client.Models.Planet;

namespace Chapter08.Client.Interfaces
{
    public interface IStarWarsApi
    {
        [Get("/planets/")]
        Task<ApiResult<List<Planet>>> GetPlanetsAsync();

        /*
        [Get("/people/")]
        Task<Response<List<Person>>> GetPeopleAsync();

        [Get("/people/{id}/")]
        Task<Person> GetPersonAsync(int id);

        //[Get("/planets/")]
        //Task<Response<List<Chapter08.Models.Planet>>> GetPlanetsAsync();

        [Get("/films/")]
        Task<Response<List<Film>>> GetFilmsAsync();


        [Get("/films/{id}/")]
        Task<Planet> GetFilmAsync(int id);
        */
    }
}
