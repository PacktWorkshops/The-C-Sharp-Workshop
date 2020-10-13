using Chapter08.Models;
using Refit;
using System.Threading.Tasks;

namespace Chapter08.Interfaces
{
    public interface IWorldTimeApi
    {
        [Get("/ip")]
        Task<DateTimeResponse> GetCurrentTime();
    }
}
