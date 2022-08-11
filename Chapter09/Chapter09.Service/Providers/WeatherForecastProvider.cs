using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Chapter09.Service.ClassMaps;
using Chapter09.Service.Dtos;
using CsvHelper;
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
                RequestUri = new Uri($"forecast?aggregateHours=1&location={location}&contentType=csv", UriKind.Relative),
            };

            using var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            using var reader = new StringReader(body);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<WeatherForecastClassMap>();
            var forecasts = csv.GetRecords<WeatherForecast>();
            return forecasts.First();
        }
    }
}
