using System.Collections.Generic;

namespace task2
{
    public class Person
    {
        public string Name { get; }
        public int Age { get; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;  
        }

        public override string ToString()
        {
            return $"{this.Name}, {this.Age}";
        }

    }

    public class PersonNameComparer : IComparer<Person>
    {
        public int Compare(Person p1, Person p2)
        {
            if (p1 is null || p2 is null)
            {
                throw new ArgumentException("Neither of arguments can be null");
            }
            if (p1.Name.Length == p2.Name.Length)
            {
                return String.Compare(p1.Name, p2.Name, StringComparison.OrdinalIgnoreCase);
            }
                return p1.Name.Length.CompareTo(p2.Name.Length);
        }
    }

    public class PersonAgeComparer : IComparer<Person>
    {
        public int Compare(Person p1, Person p2)
        {
            return p1.Age.CompareTo(p2.Age);
        }
    }
}
