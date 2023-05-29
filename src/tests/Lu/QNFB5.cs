using System.Security;

namespace FindFile
{
    public class FindFile
    {
        public static string FindFileOnDisk(string fileName)
        {
            return DeepFindFile(new DirectoryInfo("C:\\Users\\sava-"), fileName);
        }

        static string DeepFindFile(DirectoryInfo currentDirectory, string fileName)
        {
            FileInfo[] list1 = { };
            FileInfo[] list2 = { };
            try
            {
                list1 = currentDirectory.GetFiles(fileName);
            }
            catch (SecurityException) { }
            catch (UnauthorizedAccessException) { }

            try
            {
                list2 = currentDirectory.GetFiles(fileName + ".*");
            }
            catch (SecurityException) { }
            catch (UnauthorizedAccessException) { }

            if (list1.Length > 0)
            {
                return list1[0].FullName;
            }
            if (list2.Length > 0)
            {
                return list2[0].FullName;
            }

            DirectoryInfo[] subdirs = { };
            try
            {
                subdirs = currentDirectory.GetDirectories();
            }
            catch (SecurityException) { }
            catch (UnauthorizedAccessException) { }

            foreach (DirectoryInfo subdir in subdirs)
            {
                string result = DeepFindFile(subdir, fileName);
                if (result != "")
                {
                    return result;
                }
            }
            return "";
        }
    }
}