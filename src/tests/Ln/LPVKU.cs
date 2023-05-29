using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Rain
{
    class Program
    {


        static void Main(string[] args)
        {
            //надо ввести в консоль через пробел столбцы
            //в ответ программа за линейное от количества чисел время скажет,
            //сколько будет воды
            
            string str = Console.ReadLine();
            var h = str.Split(' ').Select(Int32.Parse).ToArray();
            var maxleft = new Int32[h.Length];
            var maxright = new Int32[h.Length];
            var a = 0; var b = 0; 

            for(Int32 i = 0; i < h.Length; i++)
            {
                a = Math.Max(a, h[i]);
                b = Math.Max(b, h[h.Length - 1 - i]);
                
                maxleft[i] = a;
                maxright[h.Length - 1 - i] = b;
            }
            var sum = 0;

            for(Int32 i=1; i < h.Length - 1; i++)
            {
                sum += Math.Max(Math.Min(maxleft[i-1], maxright[i + 1]) - h[i], 0) ;
            }
            Console.WriteLine(sum);
        }


        
    }
}





