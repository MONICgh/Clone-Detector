using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CollectionSorting;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var persons = new List<Person>
        {
            new Person("Vasya", 10),
            new Person("Masha", 7),
            new Person("Petya", 5),
            new Person("Max", 12),
        };
        var sortedPersons = new List<Person>
        {
            new Person("Max", 12),
            new Person("Masha", 7),
            new Person("Petya", 5),
            new Person("Vasya", 10),
        };

        persons.Sort(new FirstComparator());
        Console.WriteLine(persons[0]);
        Console.WriteLine(persons[1]);
        Console.WriteLine(persons[2]);
        Console.WriteLine(persons[3]);
        Assert.AreEqual(sortedPersons, persons);
    }

    [Test]
    public void Test2()
    {
        var persons = new List<Person>
        {
            new Person("Vasya", 10),
            new Person("Masha", 7),
            new Person("Petya", 5),
            new Person("Max", 12),
        };
        var sortedPersons = new List<Person>
        {
            new Person("Petya", 5),
            new Person("Masha", 7),
            new Person("Vasya", 10),
            new Person("Max", 12),
        };

        persons.Sort(new SecondComparator());
        Assert.AreEqual(sortedPersons, persons);
    }
}