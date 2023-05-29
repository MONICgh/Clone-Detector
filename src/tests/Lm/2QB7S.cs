using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab6
{
    class Person
    {
        public string Name;
        public int Age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }   
    }

    class NameComparer : IComparer<Person>
    {
        int IComparer<Person>.Compare(Person x, Person y)
        {
            if (x.Name.Length == y.Name.Length)
            {
                if (x.Name.Length == 0)
                    return 0;
                return x.Name.ToUpper()[0] - y.Name.ToUpper()[0];
            }
            return x.Name.Length - y.Name.Length;
        }
    }

    class AgeComparer : IComparer<Person>
    {
        int IComparer<Person>.Compare(Person x, Person y)
        {
            return x.Age - y.Age;
        }
    }
}
