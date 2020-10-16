using Chapter09.Service.Interfaces;
using Chapter09.Service.Static;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Chapter09.Service.Services
{
    public class LocalStorage : IStorage<string>
    {        
        public LocalStorage(string basePath = null)
        {
            BasePath = basePath ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Chapter09.Service");
        }

        public string BasePath { get; }

        public async Task<string> CreateItemAsync<T>(T item)
        {
            string json = Serialize(item);

            string key = StringId.NewId(7, StringIdRanges.AlphaUpper | StringIdRanges.Numeric);
            File.WriteAllText(GetFilename<T>(key), json);
            return await Task.FromResult(key);
        }

        private static string Serialize<T>(T item)
        {
            return JsonSerializer.Serialize(item, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }

        public async Task DeleteItemAsync<T>(string id)
        {
            string fileName = GetFilename<T>(id);
            File.Delete(fileName);
            await Task.CompletedTask;
        }

        public async Task<T> GetItemAsync<T>(string id)
        {
            string fileName = GetFilename<T>(id);
            string json = File.ReadAllText(fileName);
            return await Task.FromResult(JsonSerializer.Deserialize<T>(json));
        }

        public async Task UpdateItemAsync<T>(string id, T item)
        {            
            string json = Serialize(item);
            string fileName = GetFilename<T>(id);
            File.WriteAllText(fileName, json);
            await Task.CompletedTask;
        }

        public async Task<Dictionary<string, T>> QueryItemsAsync<T>(int page = 0)
        {
            const int pageSize = 10;

            // get all filenames in the T directory
            var fileNames = Directory.GetFiles(GetFolder<T>());

            // now filter this list down to the page or segment I'm looking for
            var segment = fileNames.Skip(page * pageSize).Take(pageSize);

            // get the content from this segment, along with its related filename
            var items = segment
                .Where(fileName => IsValidItem(fileName))
                .Select(fileName => new
                {
                    Key = Path.GetFileNameWithoutExtension(fileName),
                    Value = GetItem(fileName)
                });

            return await Task.FromResult(items.ToDictionary(item => item.Key, item => item.Value));

            // deserialize json within filename to desired type
            T GetItem(string fileName)
            {
                string json = File.ReadAllText(fileName);
                return JsonSerializer.Deserialize<T>(json);
            }

            // does the json in this file deserialize to the desired type?
            bool IsValidItem(string fileName)
            {
                try
                {
                    T item = GetItem(fileName);
                    return true;
                }
                catch 
                {
                    return false;
                }
            }
        }

        public void Clear<T>()
        {
            var folder = GetFolder<T>();
            var files = Directory.GetFiles(folder, "*.json");
            foreach (var file in files) File.Delete(file);
        }

        private string GetFolder<T>()
        {
            string result = Path.Combine(BasePath, typeof(T).Name);
            if (!Directory.Exists(result)) Directory.CreateDirectory(result);
            return result;
        }

        private string GetFilename<T>(string id)
        {
            return Path.Combine(GetFolder<T>(), id + ".json");                                    
        }
    }
}
