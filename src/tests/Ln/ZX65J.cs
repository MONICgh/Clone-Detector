using System;
using System.Collections.Generic;

namespace HashTable
{
    
    /// Класс Item был написан в Lab_1/HashTableWithLinkedList/HashTableWithLinkedList.cs

    public class HashTableWithOpenAdressing<TK, TV>
    {
        private int _size;
        private int _maxSize;
        private Item<TK, TV>[] _items;
        
        public HashTableWithOpenAdressing(int maxSize = 256 - 1)
        {
            _size = 0;
            _maxSize = maxSize;
            _items = new Item<TK, TV>[_maxSize];
        }
        
        private int GetHash(TK key)
        {
            return key.GetHashCode() % _maxSize;
        }
        
        private int? FindPosition(TK key)
        {
            var hash = GetHash(key);
            for (var i = 0; i < _maxSize; i++)
            {
                if (_items[hash] == null)
                {
                    break;
                }
                if (!_items[hash].IsFictitious && _items[hash].Key.Equals(key))
                {
                    return hash;
                }
                hash = (hash + 1) % _maxSize;
            }
            return null;
        }

        private int FindFreeSpace(TK key)
        {
            var hash = GetHash(key);
            while (true)
            {
                if (_items[hash] == null)
                {
                    break;
                }

                if (_items[hash].IsFictitious)
                {
                    break;
                }
                hash = (hash + 1) % _maxSize;
            }
            return hash;
        }

        private void Expand()
        {
            var tmpItems = new Item<TK, TV>[_maxSize];
            for (var i = 0; i < _maxSize; i++)
            {
                tmpItems[i] = _items[i];
            }
            _items = new Item<TK, TV>[_maxSize * 2];
            _maxSize *= 2;
            
            foreach (var item in tmpItems)
            {
                if (item == null)
                {
                    continue;
                }

                if (item.IsFictitious)
                {
                    continue;
                }
                var key = item.Key;
                var position = FindFreeSpace(key);
                _items[position] = item;
            }
        }
        
        // при переполнении лучше вообще всю хэштаблицу сформировать заново, так как, если ее просто расширить, 
        // то элементы, записанные в начало таблицы из-за того, что в конце не было уже места, 
        // не будут найдены (в моей реализации, где мы при удалении вместо написания null помечаем вершину фиктивной и
        // благодаря этому останавливаем поиск при первом null, что дает возможность не обходить всю таблицу, когда элемента там нет) 

        public void Insert(TK key, TV value)
        {
            if (_size == _maxSize)
            {
                Expand();
            }
            var item = new Item<TK, TV>(key, value);
            var position = FindFreeSpace(key);
            _items[position] = item;
            _size += 1;
        }

        public TV Find(TK key)
        {
            var position = FindPosition(key);
            if (position == null)
            {
                throw new KeyNotFoundException();
            }
            return _items[(int)position].Value;
        }
        
        /// При удалении я не освобождаю ячейку, а помечаю ее фиктивной
        /// Таким образом, искать можно будет только до первого null
        public void Delete(TK key)
        {
            var position = FindPosition(key);
            if (position == null)
            {
                return;
            }
            _items[(int)position].IsFictitious = true;
        }
    }
}