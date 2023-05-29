using NUnit.Framework;

namespace HW_07;

internal class Person : Named
{
    public Person(string name)
    {
        Name = name;
    }
}

[TestFixture]
public class Test
{
    [Test]
    public void TestConcatenate()
    {
        var data = new List<Named>
        {
            new Person("a"),
            new Person("b"),
            new Person("c"),
            new Person("d"),
            new Person("e")
        };
        Assert.AreEqual("d,e", LinqClass.Concatenate(data, ','));
    }


    [Test]
    public void TestGetPosLength()
    {
        var data = new List<Named>
        {
            new Person(""),
            new Person("b"),
            new Person("ccc"),
            new Person("dddd"),
            new Person("dddd")
        };
        Assert.AreEqual(new List<Named> { new Person("ccc"), new Person("dddd") }, LinqClass.GetPosBiggerThanLength(data).ToList());
    }


    [Test]
    public void TestRebuild()
    {
        Assert.AreEqual("Length: 4 | Count: 1\n"
            + "love\n\n"
            + "Length: 3 | Count: 1\n"
            + "dog\n\n"
            + "Length: 2 | Count: 2\n"
            + "my\n"
            + "ya\n\n"
            + "Length: 1 | Count: 1\n"
            + "I\n\n", LinqClass.RebuildSentence("I love my dog, ya"));
    }


    [Test]
    public void TestTranslate()
    {
        var dict = new Dictionary<string, string>();
        for (var c = 'a'; c <= 'z'; c++)
        {
            dict[c.ToString()] = c.ToString();
        }

        var ans = LinqClass.TranslateLinq(dict, new List<string> { "a", "b", "b", "a", "b" }, 2);
        Assert.AreEqual("A B\nB A\nB", ans);
    }

    [Test]
    public void TestSeparator()
    {
        Assert.AreEqual(new List<string> { "a  b", "cd", "d e" }, LinqClass.BucketSeparator("a  b cd d e", 3));
    }


    [Test]
    public void TestMiniMax()
    {
        var valueTuple = Tasks.maxMin(12340);
        Assert.AreEqual((Mini: 10342, Maxi: 42310), valueTuple);
    }

    [Test]
    public void TestThreeSum()
    {
        Assert.AreEqual(new List<List<int>>
        {
            new() { -1, -1, 2 },
            new() { 0, 1, -1 }
        }.ToString(), Tasks.ThreeSum(new List<int> { 0, 1, -1, -1, 2 }).ToString());
    }

}
