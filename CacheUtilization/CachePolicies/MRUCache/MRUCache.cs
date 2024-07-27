using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheUtilization.CachePolicies.MRUCache
{
    internal class MRUCache<K,V>
    {
        public readonly int capacity ;
        public readonly Dictionary<K, LinkedListNode<CacheItem>> cache;
        public readonly LinkedList<CacheItem> List; 

        public MRUCache(int _capacity)
        {
            if (_capacity<0)
            {
                throw new ArgumentException("out of bound");
            }
                
            capacity = _capacity;
            cache=new Dictionary<K, LinkedListNode<CacheItem>> (capacity);
            List=new LinkedList<CacheItem> ();

        }

        public V Get(K key)
        {

        }

        internal class CacheItem
        {
            public K Key {  get; set; }
            public V Value { get; set; }
        }
    }
}
