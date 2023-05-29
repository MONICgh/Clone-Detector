using System;

namespace MaxMin
{
    public class Solver
    {
        private readonly ulong[] powTen;

        public Solver()
        {
            powTen = new ulong[19];
            powTen[0] = 1;
            for (var i = 1; i < 19; ++i)
            {
                powTen[i] = powTen[i - 1] * 10;
            }
        }
        
        public new ulong[] MaxMin(ulong num)
        {
            var str = num.ToString();
            var len = str.Length;
            var ans = new ulong[] { num, num };
            for (var i = 0; i < len; ++i)
            {
                for (var j = i + 1; j < len; ++j)
                {
                    if (i == 0 && str[j] == '0')
                    {
                        continue;
                    }
                    var cur = num + (ulong)(str[j] - str[i]) * powTen[len - i - 1] +
                              (ulong)(str[i] - str[j]) * powTen[len - j - 1];
                    
                    if (ans[0] < cur) ans[0] = cur;
                    if (ans[1] > cur) ans[1] = cur;
                }
            }

            return ans;
        }
    }
}