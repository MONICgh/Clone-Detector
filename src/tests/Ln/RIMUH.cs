using NUnit.Framework;

namespace HashTable
{
    internal class HashTableTest
    {
        [Test]
        public void Test1()
        {
            HashTable<int> hashTable = new();
            hashTable.Add(1);
            hashTable.Add(2);
            Assert.IsTrue(hashTable.Contains(1));
            Assert.IsFalse(hashTable.Contains(3));
            hashTable.Add(3);
            hashTable.Delete(2);
            Assert.IsTrue(hashTable.Contains(3));
            Assert.IsFalse(hashTable.Contains(2));
        }

        [Test]
        public void Test2()
        {
            HashTable<string> hashTable = new();
            Assert.IsFalse(hashTable.Contains("ab"));
            hashTable.Delete("bc");
            hashTable.Add("cd");
            hashTable.Add("de");
            hashTable.Add("ef");
            hashTable.Add("ef");
            hashTable.Add("ef");
            Assert.IsTrue(hashTable.Contains("de"));
            Assert.IsTrue(hashTable.Contains("ef"));
            Assert.IsFalse(hashTable.Contains("bc"));
            hashTable.Delete("ef");
            hashTable.Delete("de");
            hashTable.Add("ce");
            Assert.IsTrue(hashTable.Contains("ce"));
            Assert.IsFalse(hashTable.Contains("ef"));
            Assert.IsFalse(hashTable.Contains("de"));
        }
    }
}
