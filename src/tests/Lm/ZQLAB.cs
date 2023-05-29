using NUnit.Framework;

namespace HW_06.PersonComparers;

public class Test
{
    [Test]
    public void Test1()
    {
        var aname = new Person(15, "aname");
        var keko = new Person(13, "keko");
        var bname = new Person(12, "bname");
        var longname = new Person(12, "longname");
        var data = new List<Person> { aname, keko, bname, longname };

        data.Sort(new NameComparer());
        Assert.AreEqual(new List<Person> { keko, aname, bname, longname }, data);
    }

    [Test]
    public void Test2()
    {
        var aname = new Person(15, "aname");
        var keko = new Person(13, "keko");
        var bname = new Person(12, "bname");
        var longname = new Person(11, "longname");
        var data = new List<Person> { aname, keko, bname, longname };

        data.Sort(new AgeComparer());
        Assert.AreEqual(new List<Person> { longname, bname, keko, aname }, data);
    }

}
