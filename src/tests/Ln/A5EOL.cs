using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HW02.HashTable
{
    public class HashTableLinear<T> : IHashTable<T>
    {
        private const int MinCapacity = 8;
        public int Count { get; private set; }
        public int Capacity { get; private set; }
        private HashTableItem<T>[] Data { get; set; }

        public HashTableLinear() : this(capacity: MinCapacity)
        {
        }

        private HashTableLinear(int capacity)
        {
            Capacity = capacity;
            Data = new HashTableItem<T>[Capacity];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Data.Where(item => item.NotEmpty).Select(item => item.Content).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private int GetItemStartIndex(T value)
        {
            var index = value.GetHashCode() % Capacity;
            if (index < 0)
                index += Capacity;
            return index;
        }
        public bool Add(T value)
        {
            if (Count * 4 >= 3 * Data.Length) // loadFactor = Size / Buckets <= 3/4
            {
                Rebuild(Capacity * 2);
            }
            var itemIndex = GetItemStartIndex(value);

            while (!Data[itemIndex].IsDeleted && !Data[itemIndex].IsEmpty)
            {
                itemIndex = GetNextItemIndex(itemIndex);
            }
            Data[itemIndex].SetContent(value);
            Count++;
            return true;
        }
        private int GetNextItemIndex(int itemIndex)
        {
            return (itemIndex + 1) % Capacity;
        }
        private void Rebuild(int newCapacity)
        {
            Capacity = newCapacity;
            var allTableElements = new List<T>(this);

            Count = 0;
            Data = new HashTableItem<T>[Capacity];
            foreach (var tableElement in allTableElements)
            {
                Add(tableElement);
            }
        }

        public bool Contains(T value)
        {
            var itemStartIndex = GetItemStartIndex(value);
            var index = itemStartIndex;
            while (Data[index].NotEmpty || Data[index].IsDeleted)
            {
                if (!Data[index].IsDeleted && Equals(Data[index].Content, value))
                {
                    return true;
                }
                index = GetNextItemIndex(index);
                if (index == itemStartIndex)
                    break;
            }
            return false;
        }

        public bool Remove(T value)
        {
            var index = GetItemStartIndex(value);
            var isValueRemoved = false;
            while (Data[index].NotEmpty || Data[index].IsDeleted)
            {
                if (!Data[index].IsDeleted && Equals(Data[index].Content, value))
                {
                    Data[index].ClearContent();
                    isValueRemoved = true;
                    break;
                }
                index = GetNextItemIndex(index);
            }

            if (isValueRemoved)
                Count--;
            // If size is too small in comparison with capacity
            // We should decrease amount of buckets
            if (8 * Count <= Capacity && Capacity >= MinCapacity * 2)
                Rebuild(Capacity / 2);
            return isValueRemoved;
        }
    }
}
