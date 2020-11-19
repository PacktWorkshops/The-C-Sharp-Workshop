using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Chapter02.Examples.CsharpKeywords.Record
{
    public record MovieRecord(string Title, string Director, string Producer, DateTime ReleaseDate)
    {
        public string Description { get; set; }
    }
}

