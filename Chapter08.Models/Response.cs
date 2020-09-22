using Newtonsoft.Json;
using Refit;
using System.Text.Json.Serialization;

namespace Chapter08.Models
{
    public class Response<T>
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("next")]
        public string Next { get; set; }

        [JsonPropertyName("previous")]
        public string Previous { get; set; }

        //[AliasAs("results")]
        //[JsonPropertyName("results")]
        [JsonProperty("results")]
        public T Data { get; set; }
    }
}
