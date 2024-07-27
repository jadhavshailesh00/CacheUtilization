
using CacheUtilization.CachePolicies.LRUCache;
using System.Diagnostics;

namespace CacheUtlization
{
    class Cache
    {
        public static void Main(String[] arg)
        {
            var lruCache = new LRUCache<int, string>(2);
            lruCache.Put(1, "one");
            lruCache.Put(2, "two");
            Console.WriteLine(lruCache.Get(1)); // outputs: one
            lruCache.Put(3, "three"); // evicts key 2
            Console.WriteLine(lruCache.Get(2)); // outputs: default (null)
            lruCache.Put(4, "four"); // evicts key 1
            Console.WriteLine(lruCache.Get(1)); // outputs: default (null)
            Console.WriteLine(lruCache.Get(3)); // outputs: three
            Console.WriteLine(lruCache.Get(4)); // outputs: four
            Console.ReadKey();
        }
    }
}