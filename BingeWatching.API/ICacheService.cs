using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingeWatching.API
{
    public interface ICacheService<K,V>
    {
        public K CurrentKey { get; set; }
        bool ContainsKey(K userId);
        void AddKey(K userId);
        bool ContainsValue(V data);
        void UpdateValue(V content);
        void AddValue(V content);
        List<V> GetValues();
    }
}
