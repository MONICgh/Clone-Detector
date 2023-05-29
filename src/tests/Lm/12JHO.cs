using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionSorting;

public class Person
{
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; }
    public int Age { get; }

    public override string ToString()
    {
        return $"Person({Name}, {Age})";
    }

    public override bool Equals(object? obj)
    {
        if (obj is Person other) return Equals(other);
        
        throw new ArgumentException("Cannot compare");

    }

    protected bool Equals(Person other)
    {
        return Name == other.Name && Age == other.Age;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Age);
    }
}

public class FirstComparator : IComparer<Person>
{
    public int Compare(Person? x, Person? y)
    {
        if (x == null || y == null) throw new ArgumentException("One of arguments is null");
        
        if (x.Name.Length == y.Name.Length)
        {
            return x.Name.ToLower()[0].CompareTo(y.Name.ToLower()[0]);
        }

        return x.Name.Length.CompareTo(y.Name.Length);
    }
} 

public class SecondComparator : IComparer<Person>
{
    public int Compare(Person? x, Person? y)
    {
        if (x == null || y == null) throw new ArgumentException("One of arguments is null");
        
        return x.Age.CompareTo(y.Age);
    }
} 
