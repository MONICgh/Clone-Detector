// See https://aka.ms/new-console-template for more information

using System.Reflection.Metadata.Ecma335;

string? FindFile(string root, string fileName)
{
    var fileInThisDir = Directory
        .GetFiles(root, fileName)
        .Select(Path.GetFullPath)
        .FirstOrDefault((string?)null);

    if (fileInThisDir != null)
    {
        return fileInThisDir;
    }
    return Directory
        .GetDirectories(root)
        .Select(Path.GetFullPath)
        .Select(it => FindFile(it, fileName))
        .Where(it => it != null)
        .FirstOrDefault((string?)null);
}

void Main(string[] args) { }
{
    if (args.Length > 0 && args[0] == "--help")
    {
        Console.WriteLine("It is FileFinder!\nUsage: $ FindFile <search root> <file_name>\nExample (on Linux): $ FindFile /home/user/dir Homework9.pdf\nExample (on Windows): > FindFile C:\\Temp Homework9.pdf");
    }
    
    if (args.Length == 2)
    {
        Console.WriteLine("Finding...");
        var searchRoot = args[0];
        var fileName = args[1];
        if (!fileName.Contains("."))
        {
            fileName += ".*";
        }

        var res = FindFile(searchRoot, fileName);
        Console.WriteLine(res != null ? $"Found here: {res}" : "Not Found");
    }
    else
    {
        Console.WriteLine("Bad arguments. See help with --help.");
    }
    
}

Main(args);
