using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace MainTasks;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var badgers = new List<Badger>
        {
            new Badger("Vasya"),
            new Badger("Petya"),
            new Badger("Kolya"),
            new Badger("Vasya"),
            new Badger("Petya"),
            new Badger("Kolya"),
        };
        Assert.AreEqual("Vasya - Petya - Kolya", Tasks.Task1(badgers, " - "));
    }

    [Test]
    public void Test2()
    {
        var badgers = new List<Badger>
        {
            new Badger("Vasya"),
            new Badger("Koko"),
            new Badger("P"),
            new Badger("Kolya"),
        };
        var expected = new List<Badger>
        {
            new Badger("Vasya"),
            new Badger("Koko"),
            new Badger("Kolya")
        };
        var res = Tasks.Task2(badgers).ToList();
        Assert.AreEqual(expected.Count, res.Count);
    }

    [Test]
    public void Test3()
    {
        var res = Tasks.Task3("Это что же получается: ходишь, ходишь в школу, а потом бац - вторая смена");
        var rightAnswer = @"Группа 4. Длина 6. Количество 3
ходишь
ходишь
вторая

Группа 6. Длина 5. Количество 3
школу
потом
смена

Группа 1. Длина 3. Количество 3
это
что
бац

Группа 5. Длина 1. Количество 2
в
а

Группа 3. Длина 10. Количество 1
получается

Группа 2. Длина 2. Количество 1
же

";
        Assert.AreEqual(rightAnswer, res);
    }

    [Test]
    public void Test4()
    {
        var text = "This dog eats too much vegetables after lunch";
        var n = 3;
        var dict = new Dictionary<string, string>
        {
            { "this", "эта" },
            { "dog", "собака" },
            { "eats", "ест" },
            { "too", "слишком" },
            { "much", "много" },
            { "vegetables", "овощей" },
            { "after", "после" },
            { "lunch", "обеда" }
        };
        var expected = new List<string>
        {
            "ЭТА СОБАКА ЕСТ",
            "СЛИШКОМ МНОГО ОВОЩЕЙ",
            "ПОСЛЕ ОБЕДА"
        }
        ;
        Assert.AreEqual(expected, Tasks.Task4(text, n, dict));
    }
    
    [Test]
    public void Test5()
    {
        Assert.AreEqual(
            new List<string> { "она продает", "морские раковины", "у моря" },
            Tasks.Task5("она продает морские раковины у моря", 16)
        );
        Assert.AreEqual(
            new List<string> { "мышь", "прыгнула", "через", "сыр" },
            Tasks.Task5("мышь прыгнула через сыр", 8)
        );
        Assert.AreEqual(
            new List<string> { "волшебная пыль", "покрыла воздух" },
            Tasks.Task5("волшебная пыль покрыла воздух", 15)
        );
        Assert.AreEqual(
            new List<string> { "a", "b", "c", "d", "e" },
            Tasks.Task5("a b  c d e ", 2)
        );
    }
}