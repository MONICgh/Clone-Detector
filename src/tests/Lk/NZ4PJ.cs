using HW_04.HorseCar;
using NUnit.Framework;

namespace HW_04.Hamsters;

public class Tests
{
    [Test]
    public void TestSorter()
    {

        RandomHamsterCreator.SetSeed(10);
        var lst = new List<Hamster>
        {
            RandomHamsterCreator.getRandom(),
            RandomHamsterCreator.getRandom(),
            RandomHamsterCreator.getRandom(),
            RandomHamsterCreator.getRandom()
        };

        HamsterSorter.SortHamsterList(lst);

        for (var i = 0; i < lst.Count - 1; i++)
        {
            Assert.Greater(lst[i].GetHamsterValue(), lst[i + 1].GetHamsterValue());
        }
    }
}
