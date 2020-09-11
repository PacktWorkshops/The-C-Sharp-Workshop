using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Chapter08.Service.Static
{
    public static class JsonFiles
    {
        public static void Save<T>(T @object, string fileName)
        {
            string json = JsonSerializer.Serialize(@object, new JsonSerializerOptions()
            {
                WriteIndented = true
            });

            File.WriteAllText(BuildPath<T>(fileName), json);
        }

        public static T Load<T>(string fileName)
        {
            string json = File.ReadAllText(BuildPath<T>(fileName));
            return JsonSerializer.Deserialize<T>(json);
        }

        public static IEnumerable<T> GetAll<T>()
        {
            throw new NotImplementedException();
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
    }
}
