using System.Collections.Generic;
using System.Threading.Tasks;
using Chapter08.Activities.Activity02;
using Chapter08.Exercises.Exercise02.Models;
using Refit;

namespace Chapter08.Activities.Activity03
{
    public interface ICountriesClient
    {
        [Get("/all")]
        public Task<IEnumerable<Country>> Get();

        [Get("/lang/{language}")]
        public Task<IEnumerable<Country>> GetByLanguage(string language);

        [Get("/capital/{capital}")]
        public Task<IEnumerable<Country>> GetByCapital(string capital);
    }
}
