using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace Chapter08.Models
{
    public class Planet
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rotation_period")]
        public string RotationPeriod { get; set; }

        [JsonProperty("orbital_period")]
        public string OrbitalPeriod { get; set; }

        [JsonProperty("diameter")]
        public string Diameter { get; set; }

        [JsonProperty("climate")]
        public string Climate { get; set; }
        public string Gravity { get; set; }
        public string Terrain { get; set; }

        [JsonProperty("surface_water")]
        public string SurfaceWater { get; set; }

        public string population { get; set; }
        public string[] residents { get; set; }
        public string[] films { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }
    }
}
