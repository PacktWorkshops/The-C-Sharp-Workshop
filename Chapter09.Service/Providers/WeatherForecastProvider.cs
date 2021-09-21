using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Chapter09.Service.Dtos;
using Newtonsoft.Json;

namespace Chapter09.Service.Providers
{
    public interface IWeatherForecastProvider
    {
        Task<WeatherForecast> GetCurrent(string location);
    }

    public class WeatherForecastProvider : IWeatherForecastProvider
    {
        private readonly HttpClient _client;

        public WeatherForecastProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<WeatherForecast> GetCurrent(string location)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"/weather?units=metric&q={location}", UriKind.Relative),
            };

            using var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<WeatherForecast>(body);
        }
    }
}
