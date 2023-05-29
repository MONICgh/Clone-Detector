using NUnit.Framework.Constraints;

namespace HashTable
{
    public class HashTable<T>
    {
        private const uint LEN = (uint)1e6;
        private const uint P1 = 101;
        private const uint P2 = 37;
        private T[] hashTable;
        private bool[] deleted;
        private bool[] exist;

        public HashTable()
        {
            hashTable = new T[LEN];
            deleted = new bool[LEN];
            exist = new bool[LEN];
        }

        public void Add(T elem)
        {
            if (elem == null || Contains(elem))
            {
                return;
            }

            for (uint i = 0; ; i++)
            {
                uint hash = ((uint) elem.GetHashCode() + i * P1 + i * i * P2) % LEN;
                if (!exist[hash])
                {
                    exist[hash] = true;
                    hashTable[hash] = elem;
                    return;
                }
            }
        }

        public void Delete(T elem)
        {
            if (elem == null)
            {
                return;
            }

            for (uint i = 0; ; i++)
            {
                uint hash = ((uint) elem.GetHashCode() + i * P1 + i * i * P2) % LEN;
                if (!exist[hash] && !deleted[hash])
                {
                    return;
                }
                if (exist[hash] && elem.Equals(hashTable[hash]))
                {
                    deleted[hash] = true;
                    exist[hash] = false;
                    return;
                }
            }
        }

        public bool Contains(T elem)
        {
            if (elem == null)
            {
                return false;
            }

            for (uint i = 0; ; i++)
            {
                uint hash = ((uint) elem.GetHashCode() + i * P1 + i * i * P2) % LEN;
                if (!exist[hash] && !deleted[hash])
                {
                    return false;
                }
                if (exist[hash] && elem.Equals(hashTable[hash]))
                {
                    return true;
                }
            }
        }
    }
}