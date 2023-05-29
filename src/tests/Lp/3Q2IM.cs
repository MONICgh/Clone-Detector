using System.Collections.Generic;
using System.Linq;

namespace AllPermutations
{
    public class Solver
    {
        private void Swap(ref char a, ref char b)
        {
            (a, b) = (b, a);
        }

        private void Reverse(char[] arr, int startIndex)
        {
            for (int start = startIndex, end = arr.Length - 1; start < end; ++start, --end)
            {
                Swap(ref arr[start], ref arr[end]);
            }
        }

        private bool NextPermutation(char[] arr)
        {
            var startIndex = arr.Length - 2;

            while (startIndex >= 0)
            {
                if (arr[startIndex] < arr[startIndex + 1])
                {
                    break;
                }

                --startIndex;
            }

            if (startIndex >= 0)
            {
                var endIndex = arr.Length - 1;
                while (endIndex > startIndex)
                {
                    if (arr[endIndex] > arr[startIndex])
                    {
                        break;
                    }

                    --endIndex;
                }

                Swap(ref arr[startIndex], ref arr[endIndex]);
                Reverse(arr, startIndex + 1);
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public string Permutations(string str)
        {
            var tmp = str.ToList();
            tmp.Sort();
            var arr = tmp.ToArray();
            var ans = new List<string>();
            do
            {
                ans.Add(string.Join("", arr));
            } while (NextPermutation(arr));
            return string.Join(" ", ans);
        }
    }
}