using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching.Redist
{
    interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int durattion);
        bool IsAdd(string key);
        void Remove(string key);
        void RemoveByPattern(string pettern);
    }
}
