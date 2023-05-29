using NUnit.Framework;

namespace SortCollection
{
    internal class SortCollectionTest
    {
        [Test]
        public void Test1()
        {
            List<Person> persons = new() { new Person("Masha", 37), new Person("Oleg", 15), new Person("nina", 28), null };
            ComparatorName comparator = new ComparatorName();
            persons.Sort(comparator);

            List<Person> correctOrder = new() { null, new Person("nina", 28), new Person("Oleg", 15), new Person("Masha", 37) };
            for (int i = 0; i < persons.Count; i++)
            {
                if (persons[i] == null)
                {
                    Assert.IsTrue(persons[i] == correctOrder[i]);
                }
                else
                {
                    Assert.IsTrue(persons[i].Name == correctOrder[i].Name && persons[i].Age == correctOrder[i].Age);
                }
            }
        }

        [Test]
        public void Test2()
        {
            List<Person> persons = new() { new Person("Masha", 11), new Person("Oleg", 42), new Person("nina", 28), null };
            ComparatorAge comparator = new ComparatorAge();
            persons.Sort(comparator);

            List<Person> correctOrder = new() { null, new Person("Masha", 11), new Person("nina", 28), new Person("Oleg", 42) };
            for (int i = 0; i < persons.Count; i++)
            {
                if (persons[i] == null)
                {
                    Assert.IsTrue(persons[i] == correctOrder[i]);
                }
                else
                {
                    Assert.IsTrue(persons[i].Name == correctOrder[i].Name && persons[i].Age == correctOrder[i].Age);
                }
            }
        }
    }
}
