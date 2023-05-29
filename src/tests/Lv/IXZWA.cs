using System.Collections;
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
    }

    class Task1
    {
        static void Main()
        {
            var delimeter = " ";

            var persons = new List<Person>() {
                new Person(1, "Person1"),
                new Person(2, "Person2"),
                new Person(3, "Person3"),
                new Person(4, "Person4"),
                new Person(5, "Person5"),
                new Person(6, "Person6"),
                new Person(7, "Person7"),
                new Person(8, "Person8"),
                new Person(9, "Person9"),
                new Person(10, "Person10")
            };
            if (persons.Count() < 4)
            {
                throw new Exception("not enought elements in persons");
            }

            var names = persons.Skip(3)
                .Select(p => p.Name)
                .Aggregate((a, b) => a + delimeter + b);
            Console.WriteLine(names);
        }
    }
}
