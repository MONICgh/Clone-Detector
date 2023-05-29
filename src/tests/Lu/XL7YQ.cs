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
            var myArray = new string[] { "12/5", "1/10", "2346/876", "1/7", "1/11", "100/400", "100/19997" };
            foreach (string str in myArray)
            {
                writting(str);
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

        static int Len (int a)
        {
            var ans = 1; var p = 10;
            while (p <= a)
            {
                ans++; p *= 10;
            }
            return ans;
        }

        static string Rational(int a, int b)
        {
            var q = GCD(a, b);
            a /= q; b /= q;

            var n = a / b;

            a = a - b * n;

            if (a == 0) return n.ToString();

            var deg = 0; // длина предпрериода.

            while (b % 10 == 0)
            {
                b /= 10; deg++;
            }

            while (b % 5 == 0)
            {
                b /= 5; deg++; a *= 2;
            }

            while (b % 2 == 0)
            {
                b /= 2; deg++; a *= 5;
            }


            var t = a / b; a = a - t * b;

            var ans = n.ToString() + ",";
            for (int i = 0; i < deg - Len(t); i++)
            {
                ans += "0";
            }
            if (t != 0) ans += t.ToString();
            
            if (b == 1) return ans;

            ans += "(";

            var temp = a;
            do
            {
                temp *= 10;
                var s = temp / b;
                ans += s.ToString();
                temp -= s * b;
            } while (temp != a);

            ans += ")";
            return ans;
        }
        static String writting(string str)
        {
            Int32 k = str.IndexOf('/');
            if (k == -1)
            {
                return str;
            }
            var b = Int32.Parse(str.Substring(k + 1));
            var a = Int32.Parse(str.Substring(0, k));


            Console.Write("Rational(" + a.ToString() + "," + b.ToString()+")" + " -> ");

            Console.WriteLine("\"" + Rational(a,b) + "\"");

            return Rational(a,b);
        }
    }
}



