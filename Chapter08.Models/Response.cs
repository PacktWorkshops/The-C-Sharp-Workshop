﻿using System.Text.Json.Serialization;

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

        [JsonPropertyName("results")]
        public T Data { get; set; }
    }
}
