using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _706_Design_HashMap
{

    // 미완성
    class Pair<U,V>
    {
        public U first;
        public V second;

        public Pair(U first, V second)
        {
            this.first = first;
            this.second = second;
        }
    }

    class Bucket
    {
        private ICollection<Pair<int, int>> bucket;
        public Bucket()
        {
            this.bucket = new LinkedList<Pair<int, int>>();
        }

        public int get(int key)
        {
            foreach (Pair<int, int> pair in this.bucket)
            {
                if (pair.first.Equals(key))
                    return pair.second;
            }
            return -1;
        }

        public void update(int key, int value)
        {
            bool found = false;
            foreach (Pair<int, int> pair in this.bucket)
            {
                if(pair.first.Equals(key))
                {
                    pair.second = value;
                    found = true;
                }
            }

            if (!found)
                this.bucket.Add(new Pair<int, int>(key, value));
        }

        public void remove(int key)
        {
            foreach (Pair<int, int> pair in this.bucket)
            {
                if (pair.first.Equals(key))
                {
                    this.bucket.Remove(pair);
                    break;
                }
            }
        }
    }

    class MyHashMap
    {
        private int key_space;
        private List<Bucket> hash_table;

        /** Initialize your data structure here. */
        public MyHashMap()
        {
            this.key_space = 2069;
            //this.hash_table = new ArrayList<Bucket>();

        }

        /** value will always be non-negative. */
        public void Put(int key, int value)
        {

        }

        /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
        public int Get(int key)
        {
            return 0;
        }

        /** Removes the mapping of the specified value key if this map contains a mapping for the key */
        public void Remove(int key)
        {

        }
    }
}
