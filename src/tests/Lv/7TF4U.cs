using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    class Person
    {
        public int Age;
        public string Name;

        public Person(int age, string name)
        {
            Age = age;
            Name = name;
        }

        public override string ToString() => string.Format("Person(Age={0}, Name={1})", Age, Name);
    }

    class Task2
    {
        static void Main()
        {
            var persons = new List<Person>() {
                new Person(0, "Person0"),
                new Person(1, "P"),
                new Person(2, "Person2"),
                new Person(3, "Person3"),
                new Person(4, "Pers"),
                new Person(5, "Person5"),
                new Person(6, "Person6"),
                new Person(7, "Per"),
                new Person(8, "Person8"),
                new Person(9, "Person9"),
                new Person(10, "Person10")
            };

            var needPersons = persons.Select((person, index) => new { Person = person, index = index })
                .Where(n => n.Person.Name.Length > n.index)
                .Select(n => n.Person).ToList();
            Console.WriteLine(needPersons.Aggregate("", (a, b) => a.ToString() + "\n" + b.ToString()));
        }
    }
}
