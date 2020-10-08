using Core.CrossCuttingCornces.Caching;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Services.Response;
using Newtonsoft.Json;

namespace Caching.redis
{
    public class RedisCacheManager : ICacheManager
    {
        private RedisServer _redisServer;

        public RedisCacheManager(RedisServer redisServer)
        {
            this._redisServer = redisServer;
        }
        public void Add(string key, object data, int duration)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            _redisServer.Database.StringSet(key, jsonData, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            if (IsAdd(key))
            {
                string jsonData = _redisServer.Database.StringGet(key);
                return JsonConvert.DeserializeObject<T>(jsonData);  
            }

            return default;
        }

        public object Get(string key)
        {
            if (IsAdd(key))
            {
                string jsonData = _redisServer.Database.StringGet(key);
                return JsonConvert.DeserializeObject<object>(jsonData);
            }

            return default;
        }

        public object Get(string key, Type type)
        {
            if (IsAdd(key))
            {
                string jsonData = _redisServer.Database.StringGet(key);
                return JsonConvert.DeserializeObject(jsonData,type);
            }

            return default;
        }

        public bool IsAdd(string key)
        {
            return _redisServer.Database.KeyExists(key);
        }

        public void Remove(string key)
        {
            _redisServer.Database.KeyDelete(key);
        }

        public void RemoveByPattern(string key)
        {
            throw new NotImplementedException();
        }
    }
}
