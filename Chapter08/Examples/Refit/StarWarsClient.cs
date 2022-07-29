using System.Collections.Generic;
using System.Threading.Tasks;
using Chapter08.Exercises.Exercise02;
using Refit;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Chapter08.Examples.Refit
{
    public interface IStarWarsClient
    {
        [Get("/films")]
        public Task<ApiResult<IEnumerable<Film>>> GetFilms();
    }
}
