using System;

namespace FractionSimplifier
{

    public class Solver
    {
        private int gcd(int a, int b)
        {
            while (true)
            {
                if (a == 0) return b;
                var a1 = a;
                a = b % a;
                b = a1;
            }
        }

        public string Simplify(string arg)
        {
            if (arg.IndexOf('/') == -1) return arg;
            var nums = arg.Split('/');
            var a = int.Parse(nums[0]);
            var b = int.Parse(nums[1]);
            if (b == 0)
            {
                throw new DivideByZeroException();
            }

            var g = gcd(a, b);
            a /= g;
            b /= g;
            if (a == 0) b = 1;
        
            return b == 1 ? a.ToString() : a + "/" + b;
        }
    }
}