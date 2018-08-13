// Class Name CacheManager
// Author- Ahmar Husain
// Compnay - (EY GDS)

namespace CORE.NG.CACHE
{
    using StackExchange.Redis;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    /// <summary>
    /// Cache Manager manages azure reddis Cache 
    /// </summary>
    public class CacheManager
    {
        private static readonly ConnectionMultiplexer connectionMultiplexer;

        /// <summary>
        /// static constructor , intializes Connection Multiplexer 
        /// </summary>
        static CacheManager()
        {
            string connectionString = "d-cache.redis.cache.windows.net:6380,password=uOLIPuYYP+TJwE2QiEYGOPCweaRz1t7RbTkcFmvmnS0=,ssl=True,abortConnect=False";
            connectionMultiplexer = ConnectionMultiplexer.Connect(connectionString);
            connectionMultiplexer.IncludeDetailInExceptions = true;

        }

        /// <summary>
        /// Get the object from the cachce based on the cache key
        /// </summary>
        /// <typeparam name="T">object</typeparam>
        /// <param name="cacheKey">cache key</param>
        /// <returns>data object from the cache</returns>
        public static T Get<T>(string cacheKey)
        {
            IDatabase cache = GetDatabase();
            if (cache != null)
                return Deserialize<T>(cache.StringGet(cacheKey));
            else
                return default(T);
        }

        /// <summary>
        /// Set cache value with a key
        /// </summary>
        /// <typeparam name="T">object</typeparam>
        /// <param name="cacheKey">Unique key</param>
        /// <param name="cacheValue">value/object to be cached</param>
        public static void Set<T>(string cacheKey, T cacheValue)
        {
            IDatabase cache = GetDatabase();
            if (cache != null)
                GetDatabase().StringSet(cacheKey, Serialize(cacheValue));

        }

        /// <summary>
        /// Remove the key from the cache
        /// </summary>
        /// <param name="key">cache key</param>
        public static void Remove(string key)
        {
            IDatabase cache = GetDatabase();
            if (cache != null)
                cache.KeyDelete(key);
        }

        /// <summary>
        /// Checks wether a key exist in the cache or not
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Exist(string key)
        {
            IDatabase cache = GetDatabase();
            return cache.KeyExists(key);

        }

        /// <summary>
        /// Flush the cache
        /// </summary>
        public static void RemoveAll()
        {
            var endpoints = connectionMultiplexer.GetEndPoints(true);
            foreach (var endpoint in endpoints)
            {
                var server = connectionMultiplexer.GetServer(endpoint);
                server.FlushAllDatabases();
            }
        }

        /// <summary>
        /// Serailaize an object into byte array
        /// </summary>
        /// <param name="obj">object that needs to be serialized</param>
        /// <returns>Byte Represntation of the object</returns>
        private static byte[] Serialize(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            BinaryFormatter objBinaryFormatter = new BinaryFormatter();
            using (MemoryStream objMemoryStream = new MemoryStream())
            {
                objBinaryFormatter.Serialize(objMemoryStream, obj);
                byte[] objDataAsByte = objMemoryStream.ToArray();
                return objDataAsByte;
            }
        }

        /// <summary>
        /// Deserializes bytes back to original object
        /// </summary>
        /// <typeparam name="T">object that bytearray converts into</typeparam>
        /// <param name="bytes">byte represntation of the cached object</param>
        /// <returns></returns>
        private static T Deserialize<T>(byte[] bytes)
        {
            BinaryFormatter objBinaryFormatter = new BinaryFormatter();
            if (bytes == null)
                return default(T);

            using (MemoryStream objMemoryStream = new MemoryStream(bytes))
            {
                T result = (T)objBinaryFormatter.Deserialize(objMemoryStream);
                return result;
            }
        }

        /// <summary>
        /// Initlaizes and return the azure reddis database
        /// </summary>
        /// <returns>Idatabase</returns>
        public static IDatabase GetDatabase()
        {
            IDatabase cache = null;
            if (connectionMultiplexer.IsConnected)
                cache = connectionMultiplexer.GetDatabase();
            return cache;
        }
    }
}
