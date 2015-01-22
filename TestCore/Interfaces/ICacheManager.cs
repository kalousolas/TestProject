﻿using System;

namespace TestCore.Interfaces
{
    public interface ICacheManager
    {
        /// <summary>
        /// Add a new object into the cache
        /// </summary>
        /// <param name="key">The key of the object to add</param>
        /// <param name="value">The value of the object to add</param>
        void Add(string key, object value);

        /// <summary>
        /// Check whether the key is contained by the cache
        /// </summary>
        /// <param name="key">The key to check</param>
        /// <returns>Returns true if the key is contained by the cache</returns>
        bool Contains(string key);

        /// <summary>
        /// Returns the number of items in the cache
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// Get the object that its key is given
        /// </summary>
        /// <typeparam name="T">The object</typeparam>
        /// <param name="key">The given key to check</param>
        /// <returns>returns the object or null if it doesn't exists</returns>
        T Get<T>(string key);

        /// <summary>
        /// Get the object that its key is given
        /// </summary>
        /// <typeparam name="T">The object</typeparam>
        /// <param name="key">The given key to check</param>
        /// <param name="getData">Function that retrieves the data </param>
        /// <returns>returns the object or null if it doesn't exists</returns>
        T SafeGet<T>(string key, Func<T> getData);

        /// <summary>
        /// Removes the object that is referenced by the given key
        /// </summary>
        /// <param name="key">The given key</param>
        bool Remove(string key);
    }


}
