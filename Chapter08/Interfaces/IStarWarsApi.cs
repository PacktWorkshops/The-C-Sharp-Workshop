using Chapter08.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter08.Interfaces
{
    public interface IStarWarsApi
    {
        [Get("/planets/?page={page}")]
        Task<ApiResult<List<Planet>>> GetPlanetsAsync(int page = 1);

        [Get("/planets/{id}/")]
        Task<Planet> GetPlanetAsync(int id);
        
        [Get("/people/?page={page}")]
        Task<ApiResult<List<Person>>> GetPeopleAsync(int page = 1);

        [Get("/people/{id}/")]
        Task<Person> GetPersonAsync(int id);

        [Get("/films/?page={page}")]
        Task<ApiResult<List<Film>>> GetFilmsAsync(int page = 1);

        [Get("/films/{id}/")]
        Task<Film> GetFilmAsync(int id);        
    }

    public static class StarWarsApiExtensions
    {
        /// <summary>
        /// this uses our more generic GetAllAsync method. Use this pattern going forward
        /// </summary>
        public static async Task<IEnumerable<Planet>> GetAllPlanetsAsync(this IStarWarsApi api) => await GetAllAsync(api, (api, page) => api.GetPlanetsAsync(page));

        public static async Task<IEnumerable<Person>> GetAllPeopleAsync(this IStarWarsApi api) => await GetAllAsync(api, (api, page) => api.GetPeopleAsync(page));

        public static async Task<IEnumerable<Film>> GetAllFilmsAsync(this IStarWarsApi api) => await GetAllAsync(api, (api, page) => api.GetFilmsAsync(page));

        /// <summary>
        /// this initial version of GetAllPlanetsAsync used a dedicated implementation not reusable with other methods,
        /// but we're keeping it because it was an acceptable solution before implementing other API endpoints
        /// </summary>
        public static async Task<IEnumerable<Planet>> GetAllPlanetsAsyncOld(this IStarWarsApi api)
        {
            List<Planet> results = new List<Planet>();

            int page = 0;
            do
            {
                page++;
                ApiResult<List<Planet>> result = await api.GetPlanetsAsync(page);
                results.AddRange(result.Data);
                if (result.Next == null) break;
            } while (true);

            return results;
        }

        /// <summary>
        /// more generic way to get all pages of any endpoint that accepts a "page" argument        
        /// </summary>
        private static async Task<IEnumerable<T>> GetAllAsync<T>(this IStarWarsApi api, Func<IStarWarsApi, int, Task<ApiResult<List<T>>>> invoke)
        {
            List<T> results = new List<T>();

            int page = 0;
            do
            {
                page++;
                ApiResult<List<T>> result = await invoke(api, page);
                results.AddRange(result.Data);
                if (result.Next == null) break;
            } while (true);

            return results;
        }

        public static async Task<IEnumerable<Planet>> GetAllPlanetsAsync(this IStarWarsApi api, Func<Planet, bool> where = null, Func<Planet, object> orderBy = null)
        {
            var results = await GetAllPlanetsAsync(api);

            if (where != null) results = results.Where(where);

            if (orderBy != null) results = results.OrderBy(orderBy);

            return results;
        }
    }
}
