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

        public static void ShowByArtistAlbum(IEnumerable<Mp3Info> files)
        {
            foreach (var artistGrp in files.GroupBy(mp3 => mp3.GroupArtistName()))
            {
                Console.WriteLine();
                Console.WriteLine(artistGrp.First().DisplayArtistName());
                foreach (var albumGrp in artistGrp.GroupBy(mp3 => mp3.GroupAlbumName()))
                {
                    Console.WriteLine($"\t{albumGrp.First().DisplayAlbumName()} - {albumGrp.First().Tag.Year}");
                    foreach (var song in albumGrp.OrderBy(mp3 => mp3.TrackNumber()))
                    {
                        Console.WriteLine($"\t\t{song.TrackNumber()}: {song.TitleOrFilename()}");
                    }

                    if (albumGrp.Count() > 1) Console.WriteLine($"\t\t{albumGrp.Count()} songs");
                }

                Console.WriteLine(
                    $"\t{artistGrp.GroupBy(mp3 => mp3.GroupAlbumName()).Count()} albums, {artistGrp.Count()} total songs");
                Console.WriteLine();
            }
        }

        public static void ShowByYearArtistAlbum(IEnumerable<Mp3Info> files)
        {
            foreach (var artistGrp in files.GroupBy(mp3 => mp3.GroupArtistName()))
            {
                Console.WriteLine();
                Console.WriteLine(artistGrp.First().DisplayArtistName());

                foreach (var yearGrp in artistGrp.GroupBy(row => row.Tag.Year.Value).OrderBy(grp => grp.Key ?? 0))
                {
                    Console.WriteLine($"\t{yearGrp.Key}");
                    foreach (var albumGrp in yearGrp.GroupBy(mp3 => mp3.GroupAlbumName()))
                    {
                        Console.WriteLine($"\t\t{albumGrp.First().DisplayAlbumName()} - {albumGrp.First().Tag.Year}");
                        foreach (var song in albumGrp.OrderBy(mp3 => mp3.TrackNumber()))
                        {
                            Console.WriteLine($"\t\t\t{song.TrackNumber()}: {song.TitleOrFilename()}");
                        }

                        if (albumGrp.Count() > 1) Console.WriteLine($"\t\t{albumGrp.Count()} songs");
                    }
                }

                Console.WriteLine(
                    $"\t{artistGrp.GroupBy(mp3 => mp3.GroupAlbumName()).Count()} albums, {artistGrp.Count()} total songs");
                Console.WriteLine();
            }
        }
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
