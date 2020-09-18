using Chapter08.Client;
using Chapter08.Client.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Chapter08
{
    class Program
    {
        static HttpClient Client = new HttpClient() 
        { 
            BaseAddress = new Uri("http://worldtimeapi.org/api/") 
        };

        static async Task Main(string[] args)
        {
            //var response = await Client.GetFromJsonAsync<DateTimeResponse>("ip");

            var client = new WorldTimeClient(Client);
            var response = await client.GetCurrentDateTime();
            Console.WriteLine($"The current date/time is {response.datetime}");
        }
    }
}
