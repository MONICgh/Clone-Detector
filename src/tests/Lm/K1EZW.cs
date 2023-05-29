using System.Collections;

namespace HW_06.PersonComparers;

public class Person
{
    public readonly string Name;
    public readonly int Age;

    public Person(int age, string name)
    {
        Age = age;
        Name = name;
    }
}

public class NameComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        var xLen = x.Name.Length;
        var yLen = y.Name.Length;

        if (xLen != yLen)
        {
            return xLen.CompareTo(yLen);
        }
        var xLetter = char.ToLower(x.Name[0]);
        var yLetter = char.ToLower(y.Name[0]);
        return xLetter.CompareTo(yLetter);
    }
}

public class AgeComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        return x.Age.CompareTo(y.Age);
    }
}
