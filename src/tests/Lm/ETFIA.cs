using System.Linq;
using NUnit.Framework;
using PersonSort;

namespace Tests.PersonSortTests
{   
    [TestFixture]
    public class PersonSortTests
    {
        [Test]
        public void TestNameSort()
        {
            var personList = Enumerable.Repeat(0, 1000).Select(_ => new Person()).ToList();
            personList.Sort(new ComparatorName());
            for (var i = 1; i < 1000; ++i)
            {
                Assert.True(personList[i - 1].Name.Length <= personList[i].Name.Length);
            }
        }

        [Test]
        public void TestAgeSort()
        {
            var personList = Enumerable.Repeat(0, 1000).Select(_ => new Person()).ToList();
            personList.Sort(new ComparatorAge());
            for (var i = 1; i < 1000; ++i)
            {
                Assert.True(personList[i - 1].Age <= personList[i].Age);
            }
        }
    }
}