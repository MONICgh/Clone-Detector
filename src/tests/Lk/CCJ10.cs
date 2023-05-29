using NUnit.Framework;

namespace CarHorse
{
    internal class CarHorseTest
    {
        [Test]
        public void Test1()
        {
            Car auto = new Car(1000, "Black", "Toyota");
            Horse horse = (Horse) auto;
            Assert.IsTrue(horse.Weight == 1000 && horse.Color == "Black" && horse.Name == "Toyota");
        }

        [Test]
        public void Test2()
        {
            Horse horse = new Horse(120, "Brown", "Loshadka");
            Car car = horse;
            Assert.IsTrue(car.Weight == 120 && car.Color == "Brown" && car.Name == "Loshadka");
        }

        [Test]
        public void Test3()
        {
            Horse horse1 = new Horse(150, "White", "Alex");
            Horse horse2 = new Horse(180, "Black", "Bob");
            Horse horse3 = new Horse(180, "Brown", "Frank");
            Horse horse4 = new Horse(150, "White", "Alex");
            Assert.IsTrue(horse1 < horse2);
            Assert.IsTrue(horse3 > horse2);
            Assert.IsTrue(horse1 == horse4);
            Assert.IsTrue(horse2 != horse4);
        }
    }
}
