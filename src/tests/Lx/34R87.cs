using System;
using System.Collections.Generic;

namespace HashTable
{
    public class Item<TK, TV>
    {
        public TK Key;
        public TV Value;
        public bool IsFictitious;

        public Item(TK key, TV value)
        {
            Key = key;
            Value = value;
            IsFictitious = false;
        }
    }
    
    public class HashTableWithLinkedList<TK, TV>
    {
        private int Size;
        private Dictionary<int, LinkedList<Item<TK, TV>>> _items;

        public HashTableWithLinkedList(int maxSize = 256 - 1)
        {
            Size = maxSize;
            _items = new Dictionary<int, LinkedList<Item<TK, TV>>>(Size);
        }

        private int GetHash(TK key)
        {
            return key.GetHashCode() % Size;
        }

        public void Insert(TK key, TV value)
        {
            var hash = GetHash(key);
            var item = new Item<TK, TV>(key, value);
            if (_items.ContainsKey(hash))
            {
                _items[hash].AddLast(item);
            }
            else
            {
                var itemsList = new LinkedList<Item<TK, TV>>();
                itemsList.AddLast(item);
                _items.Add(hash, itemsList);
            }
        }
        
        public void Delete(TK key)
        {
            var hash = GetHash(key);
            if (!_items.ContainsKey(hash))
            {
                return;
            }
            var itemsList = _items[hash];
            foreach (var item in itemsList)
            {
                if (item.Key.Equals(key))
                {
                    itemsList.Remove(item);
                    break;
                }
            }
        }
        
        public TV Find(TK key)
        {
            var hash = GetHash(key);
            if (!_items.ContainsKey(hash))
            {
                throw new KeyNotFoundException();
            }
            var itemsList = _items[hash];
            if (itemsList != null)
            {
                foreach (var item in itemsList)
                {
                    if (item.Key.Equals(key))
                    {
                        return item.Value;
                    }
                }
            }
            throw new KeyNotFoundException();
        }
    }
}