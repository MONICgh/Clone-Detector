namespace Tests;

using RainWater;
using DiceRoll;
using ImmutableType;

public class RainWaterTests
{
    [Test]
    public void Test100()
    {
        int[] heights = { 10,0,2,5,0,0,2};
        var rw = new RainWater();
        var volume = rw.CountVolume(heights);
        Console.WriteLine(volume);
    }

    [Test]
    public void Test1()
    {
        int[] heights = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
        var rw = new RainWater();
        var volume = rw.CountVolume(heights);
        Assert.AreEqual(6, volume);
    }

    [Test]
    public void Test2()
    {
        int[] heights = { 4, 2, 0, 3, 2, 5 };
        var rw = new RainWater();
        var volume = rw.CountVolume(heights);
        Assert.AreEqual(9, volume);
    }
}

public class DiceRollTests
{
    [Test]
    public void Test1()
    {
        var dr = new DiceRoll();
        var result = dr.diceRoll(2, 6);
        Assert.AreEqual(5, result);
    }
    
    [Test]
    public void Test2()
    {
        var dr = new DiceRoll();
        var result = dr.diceRoll(2, 2);
        Assert.AreEqual(1, result);
    }
    
    [Test]
    public void Test3()
    {
        var dr = new DiceRoll();
        var result = dr.diceRoll(1, 3);
        Assert.AreEqual(1, result);
    }
    
    [Test]
    public void Test4()
    {
        var dr = new DiceRoll();
        var result = dr.diceRoll(2, 5);
        Assert.AreEqual(4, result);
    }
    
    [Test]
    public void Test5()
    {
        var dr = new DiceRoll();
        var result = dr.diceRoll(3, 4);
        Assert.AreEqual(3, result);
    }
    
    [Test]
    public void Test6()
    {
        var dr = new DiceRoll();
        var result = dr.diceRoll(4, 18);
        Assert.AreEqual(80, result);
    }
    
    [Test]
    public void Test7()
    {
        var dr = new DiceRoll();
        var result = dr.diceRoll(6, 20);
        Assert.AreEqual(4221, result);
    }
    
}

public class ImmutableTypeTest
{
    [Test]
    public void Test()
    {
        var p1 = new ImmutablePair<int>(1, 2);
        p1.setFirst(4);
        Assert.AreEqual(1, p1.first);
        var p2 = p1.setFirst(4);
        Assert.AreEqual(1, p1.first);
        Assert.AreEqual(4, p2.first);
        var p3 = p2.setSecond(7);
        Assert.AreEqual(2, p2.second);
        Assert.AreEqual(7, p3.second);
    }
}