using System;
using System.Collections;
using System.Collections.Generic;

namespace Application
{
    public class NamePersonComparator : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            int result = first.Name.Length.CompareTo(second.Name.Length);
            if (result == 0)
            {
                result = first.Name.First().ToString().ToLower().CompareTo(second.Name.First().ToString().ToLower());
            }
            return result;
        }
    }

    public class AgePersonComparator : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            return first.Age.CompareTo(second.Age);
        }
    }

    public class Person
    {
        public string Name;
        public int Age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString() => String.Format("Person(Name={0}, Age={1})", Name, Age);
    }

    class Task2
    {
        static void Main()
        {
            List<Person> persons = new List<Person>() {
                new Person("Bob", 20),
                new Person("Bob2", 22),
                new Person("Bob3", 23),
                new Person("Andrew", 21),
                new Person("Andrey", 20),
                new Person("Andrei", 22),
                new Person("Andrej", 0),
                new Person("Bndrew", 19),
                new Person("Bandre", 666),
            };
            Console.WriteLine("No sort: {0}\n", String.Join(", ", persons));
            persons.Sort(new NamePersonComparator());
            Console.WriteLine("NamePersonComparator sort: {0}\n", String.Join(", ", persons));
            persons.Sort(new AgePersonComparator());
            Console.WriteLine("AgePersonComparator sort: {0}\n", String.Join(", ", persons));
        }
    }
}
