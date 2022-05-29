using Newtonsoft.Json;

namespace Chapter08.Examples.RestSharp
{
    public record ApiResult<T>
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("results")]
        public T Data { get; set; }
    }
}