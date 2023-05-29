using System.Reflection;
using TrackingAttributes;

var exampleClassType = typeof(ExampleClass);
Console.WriteLine("=====================================================");
Console.WriteLine("ExampleClass attributes:\n");
var attrs = exampleClassType.GetCustomAttributes();
Console.WriteLine(String.Join("\n-----------------------------------------------------\n", attrs));

Console.WriteLine("\n=====================================================");
Console.WriteLine("ExampleClass methods:");
foreach (var method in exampleClassType.GetMethods())
{
    Console.WriteLine("-----------------------------------------------------");
    Console.WriteLine(method.Name);
    
    foreach (var attribute in method.GetCustomAttributes())
    {
        if (attribute is CustomAttribute)
            Console.WriteLine("\n" + attribute);
    }
}

Console.WriteLine("\n=====================================================");
Console.WriteLine("ExampleClass fields:");
foreach (var field in exampleClassType.GetFields())
{
    Console.WriteLine("-----------------------------------------------------");
    Console.WriteLine(field.Name);
    
    foreach (var attribute in field.GetCustomAttributes())
    {
        if (attribute is CustomAttribute)
            Console.WriteLine("\n" + attribute);
    }
}
Console.WriteLine("=====================================================");