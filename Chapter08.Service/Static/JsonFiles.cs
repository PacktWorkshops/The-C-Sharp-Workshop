using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Chapter08.Service.Static
{
    /// <summary>
    /// This is a really simple "database" service that reads and writes json files mapped to C# types.
    /// This allows us to implement a backend API that focuses on the API portion without a complex storage dependency
    /// </summary>
    public static class JsonFiles
    {
        public static void Save<T>(T @object, string idSource)
        {
            string json = JsonSerializer.Serialize(@object, new JsonSerializerOptions()
            {
                WriteIndented = true
            });

            string fileName = $"{IdFromUrl(idSource)}.json";
            File.WriteAllText(BuildPath<T>(fileName), json);
        }

        public static void DeleteAllFiles<T>()
        {
            var folder = GetFolder<T>();
            var files = Directory.GetFiles(folder, "*", SearchOption.TopDirectoryOnly);
            foreach (var f in files) File.Delete(f);
        }

        public static T Load<T>(int id)
        {
            string fileName = $"{id}.json";
            return LoadInner<T>(BuildPath<T>(fileName));
        }

        private static T LoadInner<T>(string fileName)
        {
            string json = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<T>(json);
        }

        public static IEnumerable<T> LoadAll<T>()
        {
            var path = GetFolder<T>();
            var files = Directory.GetFiles(path, "*.json", SearchOption.TopDirectoryOnly);
            return files.Select(fileName => LoadInner<T>(fileName));
        }

        private static string BuildPath<T>(string fileName)
        {
            if (!fileName.EndsWith(".json")) fileName += ".json";

            string folder = GetFolder<T>();

            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            return Path.Combine(folder, fileName);
        }
        
        private static string GetFolder<T>()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Chapter08.Service", typeof(T).Name);
        }

        /// <summary>
        /// assumes the id we're looking for is always at the end of URL
        /// </summary>
        public static int IdFromUrl(string url)
        {
            var parts = url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            var number = parts.Last(part => part.All(c => char.IsNumber(c)));
            return int.Parse(number);
        }
    }
}
