using System;
using System.Collections.Concurrent;
using TestCore.Interfaces;

namespace TestCore.Managers
{
    public class CacheManager : ICacheManager
    {
        private readonly ConcurrentDictionary<string, object> cache;

        public CacheManager()
        {
            cache = new ConcurrentDictionary<string, object>();
        }

        public void Add(string key, object value)
        {
            cache.AddOrUpdate(key, value, (newKey, newValue) => value);
        }

        public bool Contains(string key)
        {
            return cache.ContainsKey(key);
        }

        public int Count()
        {
            return cache.Count;
        }

        public T Get<T>(string key)
        {
            return cache.ContainsKey(key) ? (T)cache[key] : default(T);
        }

        public T SafeGet<T>(string key, Func<T> getData)
        {
            return (T)cache.GetOrAdd(key, x => getData());
        }

        public bool Remove(string key)
        {
            object output;
            return cache.TryRemove(key, out output);
        }
    }
}