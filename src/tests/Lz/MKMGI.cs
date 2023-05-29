using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace SunLoungers
{
    class FreeSpace
    {
        public int SunLoungers(string s)
        {
            char[] place = ("10" + s + "01").ToCharArray();
            //Console.WriteLine("10" + s + "01");
            int ans = 0; int zeros = 0;
            int n = place.Length;
            //Console.WriteLine(n);
            for (int i = 0; i < n; i++)
            {
                if (place[i] != '0' && place[i] != '1')
                    throw new Exception("bad string");
                if (place[i] == '0')
                {
                    zeros++;
                }
                else if (zeros > 0)
                {
                    ans += (zeros - 1) / 2;
                    zeros = 0;
                }
                else { zeros = 0; }
                //Console.Write(zeros);
            }
            return ans;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var s = new FreeSpace();
            string[] a = {"10001", "00101", "0", "000", "010100000101010001001000000100"};
            foreach (string t in a)
            {
                Console.WriteLine("SunLoungers(" + t + ") -> " + s.SunLoungers(t));
            }

        }
    }
}