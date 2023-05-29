using System;

namespace StructInheritance
{
    public struct AdvancedCalculator
    {
        private SimpleCalculator _calculator;

        public int Sum(int x, int y)
        {
            return SimpleCalculator.Sum(x, y);
        }

        public int Product(int x, int y)
        {
            return SimpleCalculator.Product(x, y);
        }
        
        public int Difference(int x, int y)
        {
            return x - y;
        }

        public int Division(int x, int y)
        {
            return x / y;
        }

        public int Remainder(int x, int y)
        {
            return x % y;
        }

        public int Power(int x, int y)
        {
            return (int)Math.Pow(x, y);
        }
    }
}