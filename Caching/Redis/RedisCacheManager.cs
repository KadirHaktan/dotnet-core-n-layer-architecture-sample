using Core.CrossCuttingCornces.Caching;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Caching.Redis
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
            throw new NotImplementedException();
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
