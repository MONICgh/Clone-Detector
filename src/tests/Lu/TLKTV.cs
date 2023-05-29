using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Application
{
    class Task4
    {
        static string? pathToFile(String startDir, String filename, bool withExtension = false)
        {
            var _startDir = startDir;
            if (_startDir == "/")
            {
                _startDir = "";
            }
            foreach (String file in Directory.GetFiles(startDir))
            {
                if (withExtension)
                {
                    Regex regex = new Regex($@"{_startDir}/{filename}.(\w+)");
                    if (regex.Match(file).Success)
                    {
                        return file;
                    }
                }
                else
                {
                    if (file == $"{_startDir}/{filename}")
                    {
                        return file;
                    }
                }
            }
            foreach (String dir in Directory.GetDirectories(startDir))
            {
                var res = pathToFile(dir, filename, withExtension);
                if (res != null)
                {
                    return res;
                }
            }
            return null;
        }

        static string? findFile(String filename, String? startDir=null)
        {
            if (startDir == null)
            {
                startDir = Directory.GetCurrentDirectory();
            }
            var res = pathToFile(startDir, filename);
            if (res == null)
            {
                res = pathToFile(startDir, filename, true);
            }
            return res;
        }

        static void Main()
        {
            var currentPath = "/Users/andrew/courses/с#/c_sharp/hw9/task4/task4";
            Console.WriteLine(findFile("file", currentPath));
            Console.WriteLine(findFile("file2.txt", currentPath));
            Console.WriteLine(findFile("file3", currentPath));
            Console.WriteLine(findFile("file4", currentPath));
        }
    }
}
