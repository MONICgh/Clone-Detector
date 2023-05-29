using System;

namespace RacingCar
{
    public class TestsRacingCar
    {
        public void TestAll()
        {
            if (Test1() && Test2())
            {
                Console.WriteLine("RacingCar: tests passed.");
            }
            else
            {
                Console.WriteLine("RacingCar: tests failed.");
            }
        }

        public bool Test1()
        {
            var shortestWay = new ShortestWay(3);
            if (shortestWay.GetShortestWay() != "AA")
            {
                return false;
            }

            return true;
        }

        public bool Test2()
        {
            var shortestWay = new ShortestWay(6);
            if (shortestWay.GetShortestWay() != "AAARA")
            {
                return false;
            }

            return true;
        }
    }
}