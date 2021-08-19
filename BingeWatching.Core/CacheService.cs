using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingeWatching.API;

namespace BingeWatching.Core
{
    public class CacheService<K, V> : ICacheService<K, V>
    {
        public K CurrentKey { get; set; }
        private Dictionary<K, List<V>> dictionnary = new Dictionary<K, List<V>>();
        public void AddKey(K userId)
        {
            dictionnary[userId] = new List<V>();
        }

        public bool ContainsKey(K userId)
        {
            return dictionnary.ContainsKey(userId);
        }

        public bool ContainsValue(V data)
        {
            if (dictionnary.ContainsKey(CurrentKey))
                return dictionnary[CurrentKey].Contains(data);
            return false;
        }
        public void AddValue(V content)
        {
            dictionnary[CurrentKey].Add(content);
        }
        public void UpdateValue(V content)
        {
            dictionnary[CurrentKey].Remove(content);
            dictionnary[CurrentKey].Add(content);
        }
        public List<V> GetValues()
        {
            if (dictionnary.ContainsKey(CurrentKey))
                return dictionnary[CurrentKey];
            return new List<V>();
        }
    }
}
