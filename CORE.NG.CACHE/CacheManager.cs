using StackExchange.Redis;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace CORE.NG.CACHE
{
    public class CacheManager
    {       
        private static readonly ConnectionMultiplexer connectionMultiplexer;
        static CacheManager()
        {
            string connectionString = "d-cache.redis.cache.windows.net:6380,password=uOLIPuYYP+TJwE2QiEYGOPCweaRz1t7RbTkcFmvmnS0=,ssl=True,abortConnect=False";
            connectionMultiplexer = ConnectionMultiplexer.Connect(connectionString);
        }       
        public static T Get<T>(string cacheKey)
        {
            return Deserialize<T>(GetDatabase().StringGet(cacheKey));
        }      
        public static void Remove(string key)
        {
            IDatabase cache = GetDatabase();
            if (cache.KeyExists(key))
                cache.KeyDelete(key);    
            
        }
        public static bool Exist(string key)
        {
            return GetDatabase().KeyExists(key);
        }
        public static void RemoveAll()
        {
            var endpoints = connectionMultiplexer.GetEndPoints(true);
            foreach (var endpoint in endpoints)
            {
                var server = connectionMultiplexer.GetServer(endpoint);
                server.FlushAllDatabases();
            }
        }
        public static void Set<T>(string cacheKey, T cacheValue)
        {
            GetDatabase().StringSet(cacheKey, Serialize(cacheValue));
        }
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
        public static IDatabase GetDatabase()
        {
            IDatabase cache = null;
            if (connectionMultiplexer.IsConnected)
                cache = connectionMultiplexer.GetDatabase();
            return cache;
        }
    }
}
