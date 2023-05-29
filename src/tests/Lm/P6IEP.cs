using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PersonSort
{
    class Person
    {
        public string Name { get; }
        public int Age { get; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"{Name} {Age} ";
        }
    }

    class PeopleNameComparer : IComparer<Person>
    {
        public int Compare(Person p1, Person p2)
        {
            if (p1.Name.Length > p2.Name.Length)
                return 1;
            if (p1.Name.Length < p2.Name.Length)
                return -1;

            char s1 = char.ToUpper(p1.Name[0]);
            char s2 = char.ToUpper(p2.Name[0]);

            if (s1 > s2)
                return 1;
            if (s1 < s2)
                return -1;
            return 0;
        }
    }

    class PeopleAgeComparer : IComparer<Person>
    {
        public int Compare(Person p1, Person p2)
        {
            if (p1.Age > p2.Age)
                return 1;
            else if (p1.Age < p2.Age)
                return -1;
            else
                return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var p = new List<Person>();
            p.Add(new Person("Grigoriy", 14));
            p.Add(new Person("Ilya", 14));
            p.Add(new Person("Irina", 13));
            p.Add(new Person("Alisa", 14));
            p.Add(new Person("Alexandr", 13));
            p.Add(new Person("Vsevolod", 14));

            foreach (var a in p)
                Console.Write(a);
            Console.WriteLine("Start");

            p.Sort(new PeopleNameComparer());
            foreach (var a in p)
                Console.Write(a);
            Console.WriteLine("Name sort");

            p.Sort(new PeopleAgeComparer());
            foreach (var a in p)
                Console.Write(a);
            Console.WriteLine("Age sort");
        }
    }
}