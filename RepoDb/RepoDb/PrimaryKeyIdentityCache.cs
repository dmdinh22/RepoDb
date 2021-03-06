﻿using RepoDb.Attributes;
using RepoDb.Enumerations;
using System.Collections.Concurrent;

namespace RepoDb
{
    /// <summary>
    /// A static class used to get the cached value of data entity primary property as an identity.
    /// </summary>
    internal static class PrimaryKeyIdentityCache
    {
        private static readonly ConcurrentDictionary<string, bool> m_cache = new ConcurrentDictionary<string, bool>();

        /// <summary>
        /// Gets the <see cref="MapAttribute.Name"/> value implemented on the data entity on a target command.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="connectionString">The connection string object to be used.</param>
        /// <param name="command">The target command.</param>
        /// <returns>A boolean value indicating the identification of the column.</returns>
        public static bool Get<TEntity>(string connectionString, Command command)
           where TEntity : class
        {
            var key = $"{typeof(TEntity).FullName}.{command.ToString()}";
            var value = false;
            if (!m_cache.TryGetValue(key, out value))
            {
                var primary = PrimaryKeyCache.Get<TEntity>();
                if (primary != null)
                {
                    value = SqlDbHelper.IsIdentity<TEntity>(connectionString, command, primary.GetMappedName());
                }
                m_cache.TryAdd(key, value);
            }
            return value;
        }
    }
}
