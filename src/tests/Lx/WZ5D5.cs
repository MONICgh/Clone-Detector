using Xunit;

namespace HashTable;


public static class HashTableTest
{
    public static void DoTest()
    {
        var hashTable = new HashTable<int>();
        hashTable.Add(0);
        for (var i = 0; i < 10; i++)
        {
            hashTable.Add(i);
        }
        for (var i = 0; i < 10; i++)
        {
            Assert.True(hashTable.Contains(1));
        }
        hashTable.Delete(1);
        hashTable.Delete(2);
        Assert.False(hashTable.Contains(1));
        Assert.False(hashTable.Contains(2));
    }
}