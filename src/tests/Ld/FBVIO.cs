using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Fraction
{
    class Program
    {


        static void Main(string[] args)
        {
            //сокращение дроби
            //string str = Console.ReadLine();
            var myArray = new string[] { "12/15", "2346/876", "8/4", "1/1", "100/400","15" };
            foreach (string str in myArray)
            {
                Console.Write("Simplify(\"" + str + "\")" + " -> " );

                Console.WriteLine("\"" + Simplify(str) + "\"");
            }
        }

        static Int32 GCD(Int32 a, Int32 b)
        {
            if (a == 0) return b;
            if (b == 0) return a;
            if (a == b) return a;
            if (a == 1 || b == 1) return 1;
            if ((a % 2 == 0) && (b % 2 == 0)) return 2 * GCD(a / 2, b / 2);
            if ((a % 2 == 0) && (b % 2 != 0)) return GCD(a / 2, b);
            if ((a % 2 != 0) && (b % 2 == 0)) return GCD(a, b / 2);
            return GCD(b, (Int32)Math.Abs(a - b));
        }


        static String Simplify(string str)
        {
            Int32 k = str.IndexOf('/');
            if (k == -1)
            {
                return str;
            }
            var b = Int32.Parse(str.Substring(k + 1));
            var a = Int32.Parse(str.Substring(0,k));
            var t = GCD(a, b);
            string s = $"{a/t}" ;
            if (b > t) { 
                s += "/" + $"{b / t}"; 
            }
            return s;
        }
    }
}





