using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab9
{
    public static class HundredMillionStrings
    {
        public static void Generate(int digits)
        {
            var format = "D" + digits.ToString();

            var range = Enumerable.Range(0, (int)Math.Pow(10, digits));
            var rng = new Random();
            var query = range.OrderBy(_ => rng.Next());

            var file = File.Open("hms.txt", FileMode.Create);
            var sw = new StreamWriter(file);

            foreach (var item in query)
            {
                sw.WriteLine(item.ToString(format));
            }

            sw.Close();
        }
    }
}
