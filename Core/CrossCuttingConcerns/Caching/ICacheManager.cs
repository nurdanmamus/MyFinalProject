using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    //başka teknolojilerin cache yapısını da ileride entegre etmek istersek
    //diye interface yapısı kullanıyoruz. 
    public interface ICacheManager 
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);
        bool IsAdd(string key);//cache'de var mı kontrolü(cache'de yoksa db den getirecek)
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }
}
