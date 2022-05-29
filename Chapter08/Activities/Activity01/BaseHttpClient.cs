using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Chapter08.Activities.Activity01
{
    public class BaseHttpClient : IDisposable
    {
        private readonly HttpClient _client;

        public BaseHttpClient(string url)
        {
            _client = new HttpClient { BaseAddress = new Uri(url) };
        }

        protected HttpRequestMessage CreateGetRequest(string url)
        {
            return new HttpRequestMessage(HttpMethod.Get, new Uri(url, UriKind.Relative));
        }

        protected Task<ApiResult<IEnumerable<T>>> SendGetManyRequest<T>(HttpRequestMessage request) 
            => SendRequest<ApiResult<IEnumerable<T>>>(request);

        protected async Task<T> SendRequest<T>(HttpRequestMessage request)
        {
            var response = await _client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            var content = await response.Content.ReadAsStringAsync();
            var apiResult = JsonConvert.DeserializeObject<T>(content);

            return apiResult;
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
