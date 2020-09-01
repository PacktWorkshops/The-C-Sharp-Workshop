using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Chapter04
{
    public static class FileLinq
    {
        public static IEnumerable<FileInfo> GetFileInfosAll(string path, string searchPattern = "*") =>
            Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories)
            .Select(fileName => new FileInfo(fileName));
        
        public static IEnumerable<FileInfo> GetFileInfosLimited(string path, int limit = 0, string searchPattern = "*")
        {
            var results = new List<FileInfo>();
            AddFilesRecursive(path);
            return results;

            void AddFilesRecursive(string currentPath)
            {
                try
                {
                    var files = Directory
                        .GetFiles(currentPath, searchPattern, SearchOption.TopDirectoryOnly)
                        .Select(fileName => new FileInfo(fileName));

                    results.AddRange(files);
                }
                catch
                {
                    // do nothing (probably a permission error)
                }

                if (limit > 0 && results.Count > limit)
                {
                    results.RemoveRange(limit, results.Count() - limit);
                    return;
                }

                Directory
                    .GetDirectories(currentPath)
                    .ToList().ForEach(dir => AddFilesRecursive(dir));                
            }
        }

        public static IEnumerable<FileInfo> GetLargest(string path, int limit = 10) => 
            GetFileInfosAll(path)
            .OrderByDescending(fileInfo => fileInfo.Length)
            .Take(limit);

        public static ILookup<string, FileInfo> GetByExtension<TSort>(string path, Func<FileInfo, TSort> orderByDescending, int limitPerExt = 10) =>
            GetFileInfosAll(path)
            .GroupBy(fileInfo => fileInfo.Extension)
            .Select(grp => new
            {
                Extension = grp.Key,
                IncludeFiles = grp.OrderByDescending(orderByDescending).Take(limitPerExt)
            })
            .SelectMany(extGrp => extGrp.IncludeFiles, (extGrp, fileInfo) => new
            {
                extGrp.Extension,
                FileInfo = fileInfo
            })
            .ToLookup(extGrp => extGrp.Extension, extGrp => extGrp.FileInfo);

        public static ILookup<string, FileInfo> GetRecentByExtension(string path, int limitPerExt = 10) => 
            GetByExtension(path, fileInfo => fileInfo.LastWriteTime, limitPerExt);

        public static ILookup<string, FileInfo> GetLargestByExtension(string path, int limitPerExt = 10) => 
            GetByExtension(path, fileInfo => fileInfo.Length, limitPerExt);

        public static ILookup<int, FileInfo> PartitionBy<TOrderBy>(string path, int partitionCount, Func<FileInfo, TOrderBy> orderByDescending, int limit = 0, string searchPattern = "*") =>
            GetFileInfosLimited(path, limit, searchPattern)
            .OrderByDescending(orderByDescending)
            .Partition(partitionCount);        
    }
}
