using NUnit.Framework;

namespace CarRace
{
    internal class RacingCarTest
    {
        [Test]
        public void Test1()
        {
            Assert.True(new RacingCar(0).BuildRoute() == "");
        }

        [Test]
        public void Test2()
        {
            Assert.True(new RacingCar(3).BuildRoute() == "AA");
        }

        [Test]
        public void Test3()
        {
            Assert.True(new RacingCar(6).BuildRoute() == "AAARA");
        }

        [Test]
        public void Test4()
        {
            Assert.True(new RacingCar(-1).BuildRoute() == "RA");
        }

        [Test]
        public void Test5()
        {
            Assert.True(new RacingCar(-12).BuildRoute() == "AARAAAA");
        }

        [Test]
        public void Test6()
        {
            Assert.True(new RacingCar(10).BuildRoute() == "Can't reach this position");
        }

        [Test]
        public void Test7()
        {
            Assert.True(new RacingCar(-7).BuildRoute() == "RAAA");
        }
    }
}
