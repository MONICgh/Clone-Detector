using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashWithOpenAdressation
{
    class Program
    {
        static Int32 m = 9;
        static Int32[] hash = new Int32[m];
        static Int32 c1 = 3, c2 = 12, c3 = 15;

        static void Main(string[] args)
        {
            
            for (int i = 0; i < hash.Length; i++)
            {
                hash[i] = -1; //считаем хэш пустым
            }


        }

        static Int32 h(Int32 k, Int32 i)
        {
            return ((k + c3 +  c2 * i + c1 * i * i) % m);//считаем хэш линейно с квадратичным сдвигом
        }

        
        static Int32 HashInsert(Int32 k)
        {
            Int32 i = 0;
            do
            {
                int j = h(k, i);
                {
                    if (hash[j] == -1 || hash[j] == k) // ищем по алгоритму, куда впихнуть число.
                    {
                        hash[j] = k;

                        return j;
                    }
                    else i++;
                }
            } while (i != m);
            Console.WriteLine("error");
            return -1;
        }


        static Int32 HashSearch(Int32 k)
        {
            Int32 i = 0;
            int j = 0;
            do
            {
                j = h(k, i);
                if (hash[j] == k)
                { // как мы искали место для этого числа, так же само число и ищем
                    return j;
                }

                else i++;
            } while (hash[j] != -1 && i != m);
            return -1;
        }
    }
}