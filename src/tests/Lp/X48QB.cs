using System;
using System.IO;

namespace FileSearch
{
    public class SearchingFile
    {
        public string FindfFile(string filename, DirectoryInfo directoryInfo)
        {
            // Для формирования пути к файлу лучше воспользоваться методом Path.Combine:
            // https://docs.microsoft.com/ru-ru/dotnet/api/system.io.path.combine?view=net-6.0 
            string currentPath = directoryInfo.FullName + "/" + filename;
            if (File.Exists(currentPath))
            {
                return currentPath;
            }

            var subDirectories = directoryInfo.GetDirectories();
            foreach (DirectoryInfo subDirectoryInfo in subDirectories)
            {
                var filePath = FindfFile(filename, subDirectoryInfo);
                if (filePath == null)
                {
                    continue;
                }
                return filePath;
            }

            return null;
        }
    }
}