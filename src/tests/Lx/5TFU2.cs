using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;
using task1;

namespace Application
{
    public class HashTable<T>
    {
        private struct Node     // it's ok there not redefine hashCode
        {
            public object key;

            public T? val;

            public Node(object key, T? val = default(T))
            {
                this.key = key;
                this.val = val;
            }

            public static Node Create(object key, T? val = default(T))
            {
                return new Node(key, val);
            }

            public override bool Equals([NotNullWhen(true)] object? obj)
            {
                if (obj is Node)
                {
                    return key == ((Node)obj).key;
                }
                return false;
            }
        }

        private Dictionary<int, LinkedList<Node>> data = new Dictionary<int, LinkedList<Node>>();

        public HashTable() { }

        public HashTable(Dictionary<string, T> d) : this()
        {
            foreach(KeyValuePair<string, T> kv in d)
            {
                Add(kv.Key, kv.Value);
            }
        }

        public void Add(object key, T? value)
        {
            var hashCode = key.GetHashCode();
            if (!data.ContainsKey(hashCode))
            {
                data[hashCode] = new LinkedList<Node>();
            }
            data[hashCode].Remove(Node.Create(key));
            data[hashCode].AddLast(Node.Create(key, value));
        }

        public bool Remove(object key)
        {
            var hashCode = key.GetHashCode();
            if (!data.ContainsKey(hashCode)) return false;
            return data[hashCode].Remove(Node.Create(key));
        }

        public bool ContainsKey(object key)
        {
            var hashCode = key.GetHashCode();
            if (!data.ContainsKey(hashCode)) return false;
            return data[hashCode].Contains(Node.Create(key));
        }

        public T? this[object key]
        {
            get
            {
                var hashCode = key.GetHashCode();
                if (!data.ContainsKey(hashCode)) return default(T);
                var node = data[hashCode].Find(Node.Create(key));
                if (node is null)
                    return default(T);
                return node.Value.val;
            }
            set
            {
                Add(key, value);
            }
        }
    }
}
