using Newtonsoft.Json;
using StackExchange.Redis;

namespace ProductApi.Utilities.Cache
{
    public class RedisManager : ICacheService
    {
        private readonly IDatabase _redisServer;
        public RedisManager()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            _redisServer = redis.GetDatabase();
            
        }
        public T? GetValue<T>(string key)
        {
            var stringValue = _redisServer.StringGet(key);
            return JsonConvert.DeserializeObject<T>(stringValue);
        }

        public bool SetValue(string key, object value)
        {
            var jsonValue = JsonConvert.SerializeObject(value);
            return _redisServer.StringSet(key,jsonValue);
        }
    }
}
