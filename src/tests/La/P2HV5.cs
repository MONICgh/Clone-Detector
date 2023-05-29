
using System.Reflection;
using CustomAttributeTask;

void writeMemeberInfo(MemberInfo t)
{
    Console.WriteLine(" - {0}", t.Name);
    var attrs = t.GetCustomAttributes<Custom>();
    
    foreach (var attr in attrs)  
    {  
        Console.WriteLine(
            "    Author {0}, version {1}, reviewers: {2}\n    Description: {3}\n",
            attr.Author,
            attr.RevisionNumber,
            string.Join(", ", attr.Reviewers), 
            attr.Description
        );  
    }
}

void writeMethodsInfo(MethodInfo[] ts)
{
    foreach (var t in ts)
    {
        writeMemeberInfo(t);
    }
}

Console.WriteLine("HealthScore information:");
Console.WriteLine(" Class HealthScore");
writeMemeberInfo(typeof(HealthScore));
Console.WriteLine(" Methods of HealthScore");
writeMethodsInfo(typeof(HealthScore).GetMethods());
