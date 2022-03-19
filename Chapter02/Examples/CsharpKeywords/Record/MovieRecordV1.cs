using System;

namespace Chapter02.Examples.CsharpKeywords.Record
{
    public record MovieRecordV1
    {
        public string Title { get; }
        public string Director { get; }
        public string Producer { get; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; }

        public MovieRecordV1(string title, string director, string producer, DateTime releaseDate)
        {
            Title = title;
            Director = director;
            Producer = producer;
            ReleaseDate = releaseDate;
        }
    }
}

