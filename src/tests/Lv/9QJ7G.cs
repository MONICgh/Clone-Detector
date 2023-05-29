using System;
using System.Collections.Generic;
using System.Linq;

namespace WordBlocks
{
    class Program
    {
        static void Split(string s, int n)
        {
            var ans = SplitOnBucket(s, n);

        }
        static List<string> SplitOnBucket(string s, int n)
        {
            Console.Write(s);
            Console.WriteLine(" " + n);
            var words = s.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var ans = new List<string>();

            var cur_string_size = 0;
            var page_num = 0;
            var pages = (from word in words
                         select new
                         {
                             cur_str = cur_string_size += word.Length + 1, 
                             pg_num = cur_string_size <= n ? page_num : ++page_num,
                             new_cur_str = cur_string_size <= n ? cur_string_size : cur_string_size = word.Length,
                             Key = page_num,
                             Value = word
                         })
                        .Select(x => new { Key = x.Key, Value = x.Value })
                        .GroupBy(x => x.Key);
            foreach (var grp in pages)
            {
                ans.Add(grp
                    .Select(x => x.Value)
                    .Aggregate((x, y) => x + " " + y));
            }

            foreach (var str in ans)
            {
                Console.WriteLine(str);
            }
            return ans;
        }
        static void Main(string[] args)
        {
            Split("она продает морские раковины у моря", 16);
            Split("мышь прыгнула через сыр", 8);
            Split("волшебная пыль покрыла воздух", 15);
            Split("a b c d e ", 2);
        }
    }
}
