using System.Reflection;
using ClassAttributes;

void PrintAttributes(MemberInfo type)
{
    Console.WriteLine($"{type.Name} attributes:");
    var attributes = type.GetCustomAttributes<Custom>().ToList();
    foreach (var attr in attributes)
    {
        Console.WriteLine($"Author: {attr.Author}");
        Console.WriteLine($"RevisionNumber: {attr.RevisionNumber}");
        Console.WriteLine($"Description: {attr.Description}");
        Console.WriteLine($"Reviewers: {string.Join(' ', attr.Reviewers)}");
    }
}

var type = typeof(HealthScore);

PrintAttributes(type);
foreach (var t in type.GetMethods())
{
    PrintAttributes(t);
}