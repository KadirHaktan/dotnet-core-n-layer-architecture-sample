using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Core.CrossCuttingCornces.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);

        object Get(string key);

        object Get(string key, Type type);


        void Add(string key, object data, int duration);

        bool IsAdd(string key);

        void Remove(string key);

        void RemoveByPattern(string key);
    }
}
