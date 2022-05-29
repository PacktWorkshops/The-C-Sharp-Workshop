using System;

namespace Chapter08.Activities.Activity01
{
    public record Film
    {
        public string Title { get; set; }

        public int EpisodeId { get; set; }

        public string OpeningCrawl { get; set; }

        public string Director { get; set; }

        public string Producer { get; set; }

        public string ReleaseDate { get; set; }

        public string[] Characters { get; set; }

        public string[] Planets { get; set; }

        public string[] Starships { get; set; }

        public string[] Vehicles { get; set; }

        public string[] Species { get; set; }

        public DateTime Created { get; set; }

        public DateTime Edited { get; set; }

        public string Url { get; set; }
    }
}
