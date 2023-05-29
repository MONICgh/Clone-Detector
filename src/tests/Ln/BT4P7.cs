using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Dices
{
    class Program
    {
        

        static void Main(string[] args)
        {
            //надо ввести в консоль через пробел количество бросков и результат,
            //в ответ программа за квадратичное от чисел время скажет,
            //сколько вариантов с данным исходом
            string str = Console.ReadLine();
            var intes = str.Split(' ').Select(Int32.Parse).ToArray();
            Int32 n = intes[0];
            Int32 r = intes[1];
            Console.WriteLine(Dice(n, r));
        }


        static Int32 Dice(Int32 num, Int32 res)
        {
            Int32[,] myArray = new int[num + 1, res + 1];
            myArray[0, 0] = 1;
            for(Int32 i = 1; i <= num; i++)
            {
                for (Int32 j = 1; j <= res; j++)
                {
                    for(Int32 k = 1; k < 7; k++)
                    {
                        if(j >= k)
                        {
                            myArray[i, j] += myArray[i - 1, j - k];
                        }
                    }
                }
            }
            return myArray[num, res];
        }
    }
}




