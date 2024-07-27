using System;
using System.Collections.Generic;

namespace CacheUtilization.CachePolicies.LRUCache
{
    public class LRUCache<K, V>
    {
        private readonly int _capacity;
        private readonly Dictionary<K, LinkedListNode<CacheItem>> _cache;
        private readonly LinkedList<CacheItem> _lruList;

        public LRUCache(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException("Capacity must be greater than zero");
            }
            _capacity = capacity;
            _cache = new Dictionary<K, LinkedListNode<CacheItem>>(capacity);
            _lruList = new LinkedList<CacheItem>();
        }

        public V Get(K key)
        {
            if (_cache.TryGetValue(key, out var node))
            {
                _lruList.Remove(node);
                _lruList.AddFirst(node);
                return node.Value.Value;
            }
            return default(V); 
        }

        public void Put(K key, V value)
        {
            if (_cache.TryGetValue(key, out var node))
            {
                node.Value.Value = value;
                _lruList.Remove(node);
                _lruList.AddFirst(node);
            }
            else
            {
                if (_cache.Count >= _capacity)
                {
                    var lruNode = _lruList.Last;
                    if (lruNode != null)
                    {
                        _cache.Remove(lruNode.Value.Key);
                        _lruList.RemoveLast();
                    }
                }
                var newItem = new CacheItem { Key = key, Value = value };
                var newNode = new LinkedListNode<CacheItem>(newItem);
                _lruList.AddFirst(newNode);
                _cache[key] = newNode;
            }
        }

        internal class CacheItem
        {
            public K Key { get; set; }
            public V Value { get; set; }
        }
    }
}
