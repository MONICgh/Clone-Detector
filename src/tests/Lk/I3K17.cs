using System.Collections.Generic;
using NUnit.Framework;

namespace HamsterSort;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        HumsterGenerator generator = new HumsterGenerator();
        List<Hamster> hamsters = generator.GenerateHamsterList(10);
        Assert.AreEqual(10, hamsters.Count);
        
        List<Hamster> sortedHamsters = HamsterSort.SortHambsterList(hamsters);
        hamsters.Sort();

        Assert.AreEqual(hamsters, sortedHamsters);
    }
    
    [Test]
    public void TestEmpty()
    {
        HumsterGenerator generator = new HumsterGenerator();
        List<Hamster> hamsters = generator.GenerateHamsterList(0);
        Assert.AreEqual(0, hamsters.Count);
        
        List<Hamster> sortedHamsters = HamsterSort.SortHambsterList(hamsters);
        hamsters.Sort();

        Assert.AreEqual(hamsters, sortedHamsters);
    }
    
    [Test]
    public void TestSingle()
    {
        HumsterGenerator generator = new HumsterGenerator();
        List<Hamster> hamsters = generator.GenerateHamsterList(1);
        Assert.AreEqual(1, hamsters.Count);
        
        List<Hamster> sortedHamsters = HamsterSort.SortHambsterList(hamsters);
        hamsters.Sort();

        Assert.AreEqual(hamsters, sortedHamsters);
    }
}