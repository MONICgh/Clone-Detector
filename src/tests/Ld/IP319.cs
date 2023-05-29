using System;
using System.Collections.Generic;
using System.Text;

namespace CSDotNet.Lab3
{
    public class Simplifier
    {
        private static int GCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a | b;
        }
        public static string Simplify(string arg)
        {
            string[] subs = arg.Split('/');
            int a = int.Parse(subs[0]);
            int b = int.Parse(subs[1]);
            int gcd = GCD(a, b);
            return (a / gcd).ToString() + '/' + (b / gcd).ToString();
        }
    }
}
