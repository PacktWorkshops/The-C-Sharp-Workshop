using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chapter09.Service.Interfaces
{
    public interface IStorage<TKey>
    {
        Task<T> GetItemAsync<T>(TKey id);
        Task<TKey> CreateItemAsync<T>(T item);
        Task UpdateItemAsync<T>(TKey id, T item);
        Task DeleteItemAsync<T>(TKey id);
        Task<Dictionary<TKey, T>> QueryItemsAsync<T>(int page = 0);
    }
}
