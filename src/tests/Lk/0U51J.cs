using NUnit.Framework;

namespace HamsterSort
{
    internal class HamsterSortTest
    {
        [Test]
        public void Test1()
        {
            Random rnd = new Random(7);
            Hamster[] listHamster = new Hamster[5];
            for (int i = 0; i < listHamster.Length; i++)
            {
                listHamster[i] = new Hamster(rnd.Next(1, 101), rnd.Next(1, 101), rnd.Next(1, 101));
            }

            Array.Sort(listHamster);
            for (int i = 0; i < listHamster.Length - 1; i++)
            {
                Assert.IsTrue(listHamster[i].Value() <= listHamster[i + 1].Value());
            }
        }
    }
}
