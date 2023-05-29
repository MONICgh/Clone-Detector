string? Find(string cur, string name)
{
    var file = Directory
        .GetFiles(cur, name)
        .Select(Path.GetFullPath)
        .FirstOrDefault((string?)null);

    if (file != null)
    {
        return file;
    }

    return Directory
        .GetDirectories(cur)
        .Select(Path.GetFullPath)
        .Select(it => Find(it, name))
        .Where(it => it != null)
        .FirstOrDefault((string?)null);
}

Console.WriteLine(Find("C:\\Users\\achva\\Desktop","Homework9.pdf"));
Console.WriteLine(Find("C:\\Users\\achva\\Desktop","Homework10.pdf"));