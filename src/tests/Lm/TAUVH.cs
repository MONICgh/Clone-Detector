using System;
using System.Collections.Generic;

namespace PersonSort
{
    public class Person
    {
        public string Name;
        public int Age;

        public Person()
        {
            var rng = new Random();
            var names = new List<string> { "Alex", "John", "Max", "Joe", "Michelle", "Rachel" };
            Name = names[rng.Next() % 6];
            Age = rng.Next(15, 60);
        }
    }
}