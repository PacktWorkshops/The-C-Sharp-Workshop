using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Chapter08.Service.Static
{
    public static class JsonFiles
    {
        public static void Save<T>(T @object, string folder, string fileName)
        {
            string json = JsonSerializer.Serialize(@object, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
            File.WriteAllText(BuildPath(fileName), json);
        }

        public static T Load<T>(string folder, string fileName)
        {
            string json = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<T>(json);
        }

        public static IEnumerable<T> GetAll<T>(string folder)
        {
            throw new NotImplementedException();
        }

        private static string BuildPath(string fileName)
        {
            if (!fileName.EndsWith(".json")) fileName += ".json";

            string folder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Chapter08.Service");

            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            return Path.Combine(folder, fileName);
        }            
    }
}
