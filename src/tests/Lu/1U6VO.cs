using System.IO;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace task4
{
    class Program
    {
        public static void FindInDir(DirectoryInfo dir, string pattern, ref List<string> foundFiles, bool recursive)
        {
            try
            {
                FileInfo foundFile = dir.GetFiles(pattern)[0];
                foundFiles.Add(foundFile.FullName);

            }
            catch
            {
                if (recursive)
                {
                    foreach (DirectoryInfo subdir in dir.GetDirectories())
                    {
                        try
                        {
                            FindInDir(subdir, pattern, ref foundFiles, recursive);
                        }

                        catch
                        {
                            Console.WriteLine($"Warning: unable to access {subdir.FullName} ");
                            continue;
                        }
                    }
                } 
            }
        }

        public static List<string> FindFile(string pattern, string dir = "C:\\Users\\Anastasiia\\Pictures")
        {
            var foundFiles = new List<string>();
            FindInDir(new DirectoryInfo(dir), pattern, ref foundFiles, true);
            return foundFiles;
        }

        public static void Main(string[] args)
        {
            
            var foundFiles = FindFile("alkyne.png");
            if (foundFiles.Count == 0)
            {
                Console.WriteLine($"\n ===FILE SEARCH FINISHED=== \n File not found");
            }
            else
            {
                Console.WriteLine($"\n ===FILE SEARCH FINISHED=== \n Path to your file: {foundFiles[0]}");
            }
            /*
            ===FILE SEARCH FINISHED===
            Path to your file: C:\Users\Anastasiia\Pictures\neuroclick_article\alkyne.png
            */
        }
    }
}
