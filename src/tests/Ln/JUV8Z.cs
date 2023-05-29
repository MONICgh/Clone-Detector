using System.Collections.Generic;

namespace task1
{
    class HashTable<K, V>
    {
        private int maxSize;
        private KeyValuePair<K, V>[] hashTable;
        private int[] usedHashes;
        /*
          usedHashes:
         0 - хэш не поялялся 
         1 - по хэшу есть элемент
         2 - элемент по хэшу удален
         */
        public HashTable(int maxSize = 100)
        {
            this.maxSize = maxSize;
            hashTable = new KeyValuePair<K, V>[maxSize];
            usedHashes = new int[maxSize];
        }

        private int GetHash(K key)
        {
            return key.GetHashCode() % maxSize;
        }

        public void Add(K key, V value)
        {
            int hash = GetHash(key);
            var pair = new KeyValuePair<K, V>(key, value);
            int iterations = 0;
            while (usedHashes[hash] != 0 && usedHashes[hash] != 2)
            {
                iterations++;
                if (iterations >= maxSize)
                {
                    throw new Exception("Hash table overflow");
                }

                if (hashTable[hash].Equals(pair))
                {
                    return;
                }
                hash++;
                hash %= maxSize;
            }
            hashTable[hash] = pair;
            usedHashes[hash] = 1;
        }

        public void Delete(K key)
        {
            var hash = GetHash(key);
            int iterations = 0;

            while(usedHashes[hash] != 0 && iterations < maxSize)
            {
                iterations++;
                if (hashTable[hash].Key.Equals(key))
                {
                    usedHashes[hash] = 2;
                }
                hash++;
                hash %= maxSize;
            }
        }

        public List<V> Find(K key)
        {
            int hash = GetHash(key);
            var foundItems = new List<V>();
            while(usedHashes[hash] != 0)
            {
                if (hashTable[hash].Key.Equals(key) && usedHashes[hash] == 1)
                {
                    foundItems.Add(hashTable[hash].Value);
                }
                hash++;
                hash %= maxSize;

            }
            return foundItems;

        }


        public override string ToString()
        {
            string outputString = "";
            for(int i = 0; i < hashTable.Length; ++i)
            {
                if (usedHashes[i] == 1)
                {
                    outputString += $"{hashTable[i].Key}: {hashTable[i].Value}, ";
                }
            }
            if (outputString.Length > 0)
            {
                outputString = outputString.Remove(outputString.Length - 2, 2);
            }
            return "{" + outputString + "}";
        }

      

    }
}