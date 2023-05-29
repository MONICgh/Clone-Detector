using NUnit.Framework;

namespace Dice
{
    internal class DiceTest
    {
        [Test]
        public void Test1()
        {
            Assert.IsTrue(Dice.Combinations(2, 6) == 5);
        }

        [Test]
        public void Test2()
        {
            Assert.IsTrue(Dice.Combinations(2, 2) == 1);
        }

        [Test]
        public void Test3()
        {
            Assert.IsTrue(Dice.Combinations(1, 3) == 1);
        }

        [Test]
        public void Test4()
        {
            Assert.IsTrue(Dice.Combinations(2, 5) == 4);
        }

        [Test]
        public void Test5()
        {
            Assert.IsTrue(Dice.Combinations(3, 4) == 3);
        }

        [Test]
        public void Test6()
        {
            Assert.IsTrue(Dice.Combinations(4, 18) == 80);
        }

        [Test]
        public void Test7()
        {
            Assert.IsTrue(Dice.Combinations(6, 20) == 4221);
        }
    }
}
