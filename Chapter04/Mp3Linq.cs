using Id3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Chapter04
{
    public static class Mp3Linq
    {
        private const string Mp3Filter = "*.mp3";

        public static IEnumerable<Mp3Info> GetMp3InfoAll(string path) =>
            FileLinq.GetFileInfosAll(path, Mp3Filter)
            .Select(fileInfo => new Mp3Info(fileInfo));

        public static IEnumerable<Mp3Info> GetMp3InfoLimited(string path, int limit = 0) =>
            FileLinq.GetFileInfosLimited(path, limit, Mp3Filter)
            .Select(fileInfo => new Mp3Info(fileInfo));

        public static IEnumerable<Mp3Info> GetMp3InfoLimitedWhere(string path, Func<Mp3Info, bool> predicate, int limit = 0) =>
            FileLinq.GetFileInfosLimited(path, limit, Mp3Filter)
            .Select(fileInfo => new Mp3Info(fileInfo))
            .Where(predicate);        
    }

    public class Mp3Info
    {
        public Mp3Info(FileInfo fileInfo)
        {
            FileInfo = fileInfo;

            using (var mp3 = new Mp3(fileInfo.FullName))
            {
                Tag = mp3.GetTag(Id3TagFamily.Version2X);
            }
        }

        public FileInfo FileInfo { get; }
        public Id3Tag Tag { get; }

        public string GroupArtistName() => Tag?.Artists?.Value?.FirstOrDefault()?.ToLower().Trim() ?? "<unknown artist>";
        public string DisplayArtistName() => Tag?.Artists?.Value?.FirstOrDefault() ?? "<unknown artist>";
        public string GroupAlbumName() => Tag?.Album?.Value?.ToLower() ?? "<unknown album>";
        public string DisplayAlbumName() => Tag?.Album?.Value ?? "<unknown album>";
        public int TrackNumber() => Tag?.Track ?? 0;
        public string TitleOrFilename() => (!string.IsNullOrEmpty(Tag?.Title?.Value)) ? Tag.Title.Value : FileInfo.Name;
    }
}
