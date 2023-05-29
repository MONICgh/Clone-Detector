using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;

namespace Application
{
    class Task4
    {
        static void showJoinTables(string path1, string path2)
        {
            var lines1 = new List<string>(System.IO.File.ReadAllLines(path1));
            if (lines1.Count() == 0)
            {
                throw new Exception("wrong table1");
            }
            var columns = new List<string>(lines1[0].Split(null));
            lines1.RemoveAt(0);

            var lines2 = new List<string>(System.IO.File.ReadAllLines(path2));
            if (lines2.Count() == 0)
            {
                throw new Exception("wrong table2");
            }
            var columns2 = new List<string>(lines2[0].Split(null));
            lines2.RemoveAt(0);

            columns2.RemoveAt(0);
            foreach (string collumn in columns2)
            {
                if (columns.Any(item => item == collumn)) {
                    throw new Exception(String.Format("same collumns in table: {0}", collumn));
                }
            }
            columns.AddRange(columns2);

            var dictLines2 = new Dictionary<string, List<string>>();
            foreach (string line2 in lines2)
            {
                var idLines = line2.Split(null, 2);
                var id = idLines[0];
                var lines = idLines[1];
                if (!dictLines2.ContainsKey(id))
                {
                    dictLines2[id] = new List<string>();
                }
                dictLines2[id].Add(lines);
            }

            Console.WriteLine("{0}", String.Join("\t", columns));
            foreach (string line1 in lines1)
            {
                var idLines = line1.Split(null, 2);
                var id = idLines[0];
                if (dictLines2.ContainsKey(id))
                {
                    foreach (string line2 in dictLines2[id])
                    {
                        Console.WriteLine("{0}\t{1}", line1, line2);
                    }
                }
            }
        }

        static void Main()
        {
            string path1 = "/Users/andrew/courses/с#/c_sharp/hw6/task4/task4/table1.csv";
            string path2 = "/Users/andrew/courses/с#/c_sharp/hw6/task4/task4/table2.csv";
            showJoinTables(path1, path2);
        }
    }
}
