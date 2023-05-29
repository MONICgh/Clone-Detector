using System;
using NUnit.Framework;

namespace Interfaces;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        SumClass calculator = new SumClass();
        
        Assert.AreEqual(4 + 5, calculator.Operation(4, 5));
        Assert.AreEqual(4 * 5, ((IProd)calculator).Operation(4, 5));
        Assert.AreEqual(Math.Pow(4, 5), ((IPow)calculator).Operation(4, 5));
    }
}