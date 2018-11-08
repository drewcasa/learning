using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.SetsAndMaps
{

    /// <summary>
    /// [0..1000000]
    /// </summary>
    public class MyHashSet
    {
        List<int>[] buckets;

        /** Initialize your data structure here. */
        public MyHashSet()
        {
            buckets = new List<int>[1000];
        }

        public void Add(int key)
        {
            var hashCode = key % 1000;
            var bucket = buckets[hashCode] ?? (buckets[hashCode] = new List<int>());

            if (!bucket.Contains(key)) bucket.Add(key);
        }

        public void Remove(int key)
        {
            var hashCode = key % 1000;
            buckets[hashCode]?.Remove(key); // handles if not exists
        }

        /** Returns true if this set contains the specified element */
        public bool Contains(int key)
        {
            var hashCode = key % 1000;
            return buckets[hashCode]?.Contains(key) ?? false;
        }
    }

}
