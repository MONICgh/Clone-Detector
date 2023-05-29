namespace HashTable
{
    public class HashTable<T>
    {
        private const uint LEN = (uint) 1e6;
        private List<T>[] hashTable;
        public HashTable()
        {
            hashTable = new List<T>[LEN];
            for (int i = 0; i < LEN; i++)
            {
                hashTable[i] = new List<T>();
            }
        }
        public void Add(T elem)
        {
            if (elem != null)
            {
                uint hash = (uint) elem.GetHashCode() % LEN;
                if (!hashTable[hash].Contains(elem))
                {
                    hashTable[hash].Add(elem);
                }
            }
        }

        public void Delete(T elem)
        {
            if (elem != null)
            {
                uint hash = (uint) elem.GetHashCode() % LEN;
                hashTable[hash].Remove(elem);
            }
        }

        public bool Contains(T elem)
        {
            if (elem != null)
            {
                uint hash = (uint) elem.GetHashCode() % LEN;
                return hashTable[hash].Contains(elem);
            }
            return false;
        }
    }
}