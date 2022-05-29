using Newtonsoft.Json;

namespace Chapter08.Exercises.Exercise02
{
    public record ApiResult<T>
    {
        public int Count { get; set; }

        public string Next { get; set; }

        public string Previous { get; set; }

        [JsonProperty("results")]
        public T Data { get; set; }
    }
}