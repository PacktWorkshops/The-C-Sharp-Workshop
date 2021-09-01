using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Chapter08.Exercises.Exercise02.Models
{
    public class ApiResult<T>
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonPropertyName("results")]
        [JsonProperty("results")]
        public T Data { get; set; }
    }
}