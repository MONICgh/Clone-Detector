using NUnit.Framework;

namespace HW_08;

[TestFixture]
public class Tests
{
    [Test]
    public void TestSerializeGerman()
    {
        const string s = "Ich habe Musik gehört";
        Assert.AreEqual(s, StringSolver.Serializer.Deserialize(StringSolver.Serializer.Serialize(s)));

    }

    [Test]
    public void TestSerializeRus()
    {
        const string s = "Я послушал музыку";
        Assert.AreEqual(s, StringSolver.Serializer.Deserialize(StringSolver.Serializer.Serialize(s)));

    }

    [Test]
    public void TestSerializeJapan()
    {
        const string s = "私は音楽を聴いていました";
        Assert.AreEqual(s, StringSolver.Serializer.Deserialize(StringSolver.Serializer.Serialize(s)));

    }

    [Test]
    public void TestExceptionDispatcher()
    {
        var exc = new ExceptionWorker();
        exc.RunComplicatedLogicWhichIsDefinitelySafe();
        Assert.Throws<Exception>(() => exc.Getter());
    }


    [Test]
    public void testDiffersInOneSymbol()
    {
        Assert.IsTrue(StringSolver.DiffersInOneSymbol("aba", "caba"));
    }

    [Test]
    public void TestMerger()
    {
        var s1 = "Шла Саша по Шоссе";
        var s2 = "Шла Маша по Поссе";
        Assert.AreEqual("Шла Саша Маша по Шоссе Поссе", StringSolver.Merger(s1, s2));
    }

    [Test]
    public void TestSorter()
    {
        Assert.AreEqual("aA2", StringSolver.Sorter("2aA"));

        Assert.AreEqual("aAeE12", StringSolver.Sorter("eA2a1E"));
    }

    [Test]
    public void TestFibs()
    {
        Assert.AreEqual("b, a, ab, aba, abaab, abaababa, abaababaabaab", StringSolver.FibonacciStr(7));
    }

    [Test]
    public void TestDuplicates()
    {
        Assert.AreEqual("ask", StringSolver.MostFrequentSubstr("mask4cask"));
    }
}
