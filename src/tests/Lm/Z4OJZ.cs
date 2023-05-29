using System.Collections.Generic;
using System;

namespace SortingCollections
{
    public class Person
    {
        public string Name;
        public int Age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    public class PersonsNameComparer : IComparer<Person>
    {
        public int Compare(Person p1, Person p2)
        {
            if (object.Equals(p1, p2))
            {
                return 0;
            }

            return String.Compare(p1.Name, p2.Name, StringComparison.Ordinal);
        }
    }
    
    public class PersonsAgeComparer : IComparer<Person>
    {
        public int Compare(Person p1, Person p2)
        {
            if (object.Equals(p1, p2))
            {
                return 0;
            }

            return p1.Age.CompareTo(p2.Age);
        }
    }
}