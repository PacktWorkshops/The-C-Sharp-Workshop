using Newtonsoft.Json;
using System;

namespace Chapter08.Models
{
    /// <summary>
    /// using Newtonsoft JsonProperty attributes here in case we use this is Refit
    /// </summary>
    public class Film
    {
        [JsonProperty("title")]        
        public string Title { get; set; }

        [JsonProperty("episode_id")]        
        public int EpisodeId { get; set; }

        [JsonProperty("opening_crawl")]        
        public string OpeningCrawl { get; set; }

        [JsonProperty("director")]                
        public string Director { get; set; }

        [JsonProperty("producer")]        
        public string Producer { get; set; }

        [JsonProperty("release_date")]        
        public string ReleaseDate { get; set; }

        [JsonProperty("characters")]
        public string[] Characters { get; set; }

        [JsonProperty("planets")]
        public string[] Planets { get; set; }

        [JsonProperty("starships")]
        public string[] Starships { get; set; }

        [JsonProperty("vehicles")]
        public string[] Vehicles { get; set; }

        [JsonProperty("species")]
        public string[] Species { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("edited")]
        public DateTime Edited { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
