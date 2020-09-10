using Chapter08.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Chapter08
{
    class Program
    {
        static HttpClient Client = new HttpClient() { BaseAddress = new Uri("https://swapi.dev/api/") };

        static async Task Main(string[] args)
        {
            //var response = await Client.GetAsync("people/1/");
            //var data = await response.Content.ReadAsStringAsync();

            //var result = await Client.GetFromJsonAsync<Person>("people/1/");

            //var result = await Client.GetFromJsonAsync<List<Person>>("people/");
            var response = await Client.GetAsync("people/");
            //var data = await response.Content.ReadAsStringAsync();

            var result = await Client.GetFromJsonAsync<Result<List<Person>>>("people/");
            int page = 0;

            while (true)
            {
                page++;
                Console.WriteLine($"\npage {page}");
                
                foreach (var person in result.Data)
                {
                    Console.WriteLine(person.Name);
                }

                if (result.Next == null) break;
                
                result = await Client.GetFromJsonAsync<Result<List<Person>>>(result.Next);                
            } 
        }
    }
}
