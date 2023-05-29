using Task2;

Console.WriteLine("HealthScore attributes of the class:");
foreach (var customAttribute in typeof(HealthScore).GetCustomAttributes(true))
{
    Console.WriteLine(customAttribute.ToString());
}

foreach (var method in typeof(HealthScore).GetMethods())
{
    Console.WriteLine("Method: " + method.Name);
    foreach (var attribute in method.GetCustomAttributes(true))
    {
        Console.WriteLine("\t" + attribute);
    }
}