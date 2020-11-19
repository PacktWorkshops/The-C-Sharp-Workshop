using System;

namespace Chapter02.Examples.CsharpKeywords.Record
{
    public class MovieClass
    {
        public string Title { get; }
        public string Director { get; }
        public string Producer { get; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; }

        public MovieClass(string title, string director, string producer, DateTime releaseDate)
        {
            Title = title;
            Director = director;
            Producer = producer;
            ReleaseDate = releaseDate;
        }
    }
}

