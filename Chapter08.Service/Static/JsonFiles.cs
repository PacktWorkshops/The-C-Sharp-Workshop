using System;
using System.Text.Json;

namespace Chapter08.Service.Static
{
    public static class JsonFiles
    {
        public static void Save<T>(T @object, string fileName)
        {
            string json = JsonSerializer.Serialize<T>(@object);
            System.IO.File.WriteAllText(BuildPath(fileName), json);
        }

        public static T Load<T>(string fileName)
        {
            string json = System.IO.File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<T>(json);
        }

        private static string BuildPath(string fileName)
        {
            if (!fileName.EndsWith(".json")) fileName += ".json";

            return System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Chapter08.Service",
                fileName);
        }            
    }
}
