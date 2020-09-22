using Chapter08.Client.Models;
using Refit;
using System.Threading.Tasks;

namespace Chapter08.Client.Interfaces
{
    public interface IWorldTimeApi
    {
        [Get("/ip")]
        Task<DateTimeResponse> GetCurrentTime();
    }
}
