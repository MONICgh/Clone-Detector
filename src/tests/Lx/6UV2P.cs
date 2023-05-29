using System.Collections.Generic;

namespace task1
{
    class HashTable<K, V>
    {
        private int maxSize;
        private Dictionary<int, LinkedList<KeyValuePair<K, V>>> items;

        public HashTable(int maxSize=100)
        {   
            this.maxSize = maxSize;
            items = new Dictionary<int, LinkedList<KeyValuePair<K, V>>>();
        }

        private int GetHash(K key)
        {
            return key.GetHashCode() % maxSize;
        }

        public bool HasKey(K key)
        {
            int hash = GetHash(key);
            if (!items.ContainsKey(hash))
            {
                return false;
            }
            else
            {
                var itemsList = items[hash];
                foreach (var item in itemsList)
                {
                    if (item.Key.Equals(key))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Add(K key, V value)
        {
            int hash = GetHash(key);
            var newPair = new KeyValuePair<K, V>(key, value);
            if (items.ContainsKey(hash))
            {   
                if (HasKey(key))
                {
                    Delete(key);
                }
                items[hash].AddLast(newPair);
            }
            else
            {
                var newItem = new LinkedList<KeyValuePair<K, V>>();
                newItem.AddLast(newPair);
                items.Add(hash, newItem);
            }
        }

        public void Delete(K key)
        {
            int hash = GetHash(key);
            if (!items.ContainsKey(hash))
            {
                return;
            }
            else
            {
                var itemsList = items[hash];
                foreach (var item in itemsList)
                {
                    if (item.Key.Equals(key))
                    {
                        itemsList.Remove(item);
                        break;
                    }
                }
            }
        }

        public V Find(K key)
        {
            int hash = GetHash(key);
            if (!items.ContainsKey(hash))
            {
                throw new KeyNotFoundException("No such key in the table");
            }
            else
            {
                var itemsList = items[hash];
                foreach(var item in itemsList)
                {
                    if (item.Key.Equals(key))
                    {
                        return item.Value;  
                    }
                }
                throw new KeyNotFoundException("No such key in the table");
            }
        }

        public override string ToString()
        {
            string outputString = "";
            foreach (var hashKey in items.Keys)
            {
                var itemsList = items[hashKey];
                foreach (var item in itemsList)
                {
                    outputString += $"{item.Key}: {item.Value}, ";
                }
            }
            outputString = outputString.Remove(outputString.Length - 2, 2);
            return "{" + outputString + "}";
        }
           
        
    }
}
