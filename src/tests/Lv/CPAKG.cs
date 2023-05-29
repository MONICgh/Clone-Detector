using System;
using System.Linq;
using System.Text;

namespace Lab_7_Task_3
{
    public class Task3
    {
        private string StripPunctuation(string s)
        {
            var sb = new StringBuilder();
            foreach (char c in s)
            {
                if (!char.IsPunctuation(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }
        
        public void DoTask3(string sentence)
        {
            var subs = StripPunctuation(sentence).Split(' ');
            var groups = subs
                .GroupBy(x => x.Length)
                .Select(x => (length: x.Key, count: x.Count(), value: x))
                .OrderByDescending(x => x.count);

            var index = 0;
            foreach (var group in groups)
            {
                if (group.length == 0) continue;
                Console.WriteLine("Группа " + (index + 1) + ". " + "Длина " + group.length + ". " + "Количество " + group.count);
                foreach(var value in group.value)
                {
                    Console.WriteLine(value.ToLower());
                }

                index++;
            }
        }
    }
}