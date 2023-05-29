using System.Globalization;

namespace Task2;

public class Person
{
    public readonly string Name;
    public int Age;

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
}