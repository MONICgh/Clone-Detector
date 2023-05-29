using System.Reflection;
using NUnit.Framework;

namespace Homework8;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("тест на русском")]
    [TestCase("test auf Deutsch")]
    [TestCase("日本語でのテスト")]
    public void TestStringSerialization(string str)
    {
        byte[] encoded = Tasks.serializeString(str);
        string decoded = Tasks.deserializeString(encoded);
        Assert.AreEqual(str, decoded);
    }
    
    [TestCase("124", "123")]
    [TestCase("12", "123")]
    [TestCase("123", "12")]
    [TestCase("123", "1_23")]
    public void TestStringComparatorTrue(string a, string b)
    {
        Assert.AreEqual(true, Tasks.compareStrings(a, b));
    }
    
    [TestCase("123", "1")]
    [TestCase("123", "123000")]
    [TestCase("123", "123")]
    public void TestStringComparatorFalse(string a, string b)
    {
        Assert.AreEqual(false, Tasks.compareStrings(a, b));
    }
    
    [Test]
    public void TestMergeStrings()
    {
        var a = "Шла Маша по шоссе пешком";
        var b = "Шла Саша по горе";
        var expected = "Шла Маша Саша по шоссе пешком горе";
        Assert.AreEqual(expected, Tasks.mergeStrings(a, b));
    }

    [TestCase("eA2a1E", "aAeE12")]
    [TestCase("Re4r", "erR4")]
    [TestCase("6jnM31Q", "jMnQ136")]
    [TestCase("846ZIbo", "bIoZ468" )]
    public void TestSortString(string str, string sorted)
    {
        Assert.AreEqual(sorted, Tasks.sortString(str));
    }
    
    
    [TestCase(1, "invalid" )]
    [TestCase(3, "b, a, ab" )]
    [TestCase(7, "b, a, ab, aba, abaab, abaababa, abaababaabaab" )]
    public void TestStringifyFib(int n, string fib)
    {
        Assert.AreEqual(fib, Tasks.stringifyFib(n));
    }
}