using System;
using NUnit.Framework;
using PalindromeSequence;

namespace PalindromeSequenceSpace;

public class Tests
{

    public PalindromeSequenceClass PalSeq { get; set; }
    
    [SetUp]
    public void Setup()
    {
        PalSeq = new PalindromeSequenceClass();
    }

    [Test]
    public void Test1()
    {
        Assert.AreEqual(Tuple.Create(1, 0), PalSeq.PalSeq(1));
    }
    
    [Test]
    public void Test2()
    {
        Assert.AreEqual(Tuple.Create(5, 2), PalSeq.PalSeq(11));
    }
    
    [Test]
    public void Test3()
    {
        Assert.AreEqual(Tuple.Create(3, 9), PalSeq.PalSeq(4884));
    }
    
    [Test]
    public void Test4()
    {
        Assert.AreEqual(Tuple.Create(199, 3), PalSeq.PalSeq(3113));
    }
}