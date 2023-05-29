using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Tickets
{
    class Program
    {


        static void Main(string[] args)
        {
            //
            //string str = Console.ReadLine();
            var str = "2 4 6 8 10 12";
            var intes = str.Split(' ').Select(Int32.Parse).ToArray();
            foreach (var n in intes)
            {
                Console.WriteLine("LuckyTicket(" + n + ") -> " + LuckyTicket(n / 2));
            }
        }


        static Int32 Dice(Int32 num, Int32 res)
        {
            Int32[,] myArray = new int[num + 1, res + 1];
            myArray[0, 0] = 1;
            for (Int32 i = 1; i <= num; i++)
            {
                for (Int32 j = 0; j <= res; j++)
                {
                    for (Int32 k = 0; k < 10; k++)
                    {
                        if (j >= k)
                        {
                            myArray[i, j] += myArray[i - 1, j - k];
                        }
                    }
                }
            }
            return myArray[num, res];
        }

        static Int64 LuckyTicket(Int32 n)
        {
            Int64 ans = 0;
            for (int i = 0; i <= 10 * n; i++)
            {
                Int64 a = Dice(n, i);
                ans += a * a;
            }
            return ans;
        }
    }
}




