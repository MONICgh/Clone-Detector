using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrimeFactors
{
    class Number
    {
        private int Num;
        public Number(int num)
        {
            Num = num;
        }

        public string ExpressFactors()
        {
            var dict = new Dictionary<int, int>();
            var i = 2;
            var tmp = Num;
            while (i <= tmp)
            {
                while (tmp % i == 0)
                {
                    tmp /= i;
                    if (dict.ContainsKey(i))
                    {
                        dict[i] += 1;
                    }
                    else
                    { 
                        dict.Add(i, 1);
                    }
                }

                i += 1;
            }
            
            var answer = "";
            dict = dict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            
            foreach(var item in dict)
            {
                if (item.Value == 1)
                {
                    answer += item.Key.ToString() + "x";
                }
                else
                {
                    answer += item.Key + "^" + item.Value + "x";
                }
            }
            
            return answer.Remove(answer.Length - 1, 1);
        }
    }
    
}