using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace FrogAndLake;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestOddLength()
    {
        var stones = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
        var stonesPath = new List<int> { 1, 3, 5, 7, 6, 4, 2 };
        Lake lake = new Lake(stones);

        foreach (var stone in lake.Zip(stonesPath))
        {
            Assert.AreEqual(stone.First, stone.Second);
        }
    }

    [Test]
    public void TestEvenLength()
    {
        var stones = new List<int> { 1, 2, 3, 4, 5, 6 };
        var stonesPath = new List<int> { 1, 3, 5, 6, 4, 2 };
        Lake lake = new Lake(stones);

        foreach (var stone in lake.Zip(stonesPath))
        {
            Assert.AreEqual(stone.First, stone.Second);
        }
    }

    [Test]
    public void TestEmpty()
    {
        var stones = new List<int>();
        var stonesPath = new List<int>();
        Lake lake = new Lake(stones);

        foreach (var stone in lake.Zip(stonesPath))
        {
            Assert.AreEqual(stone.First, stone.Second);
        }
    }

    [Test]
    public void TestOneElement()
    {
        var stones = new List<int> {1};
        var stonesPath = new List<int> {1};
        Lake lake = new Lake(stones);

        foreach (var stone in lake.Zip(stonesPath))
        {
            Assert.AreEqual(stone.First, stone.Second);
        }
    }
}