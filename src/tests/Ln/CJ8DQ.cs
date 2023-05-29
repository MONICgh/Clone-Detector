using NUnit.Framework;

namespace RainWater
{
    internal class RainWaterTest
    {
        [Test]
        public void TestM()
        {
            int[] borders = { 1, 2, 3, 4, 5 };
            RainWater water = new RainWater(borders);
            Console.WriteLine(water.WaterVolume());
        }

        [Test]
        public void Test1()
        {
            int[] borders = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            RainWater water = new RainWater(borders);
            Assert.IsTrue(water.WaterVolume() == 6);
        }

        [Test]
        public void Test2()
        {
            int[] borders = { 4, 2, 0, 3, 2, 5 };
            RainWater water = new RainWater(borders);
            Assert.IsTrue(water.WaterVolume() == 9);
        }
    }
}
