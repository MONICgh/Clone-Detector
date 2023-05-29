// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;
using BlackBoxTask;

var reflector = new BlackBoxReflector();

Dictionary<Regex, Action<int>> operations = new Dictionary<Regex, Action<int>>
{
    { new Regex(@"Add\((?:\d+)\)$"), x => reflector.Add(x) },
    { new Regex(@"Subtract\(\d+\)$"), x => reflector.Subtract(x)},
    { new Regex(@"Multiply\(\d+\)$"), x => reflector.Multiply(x)},
    { new Regex(@"Divide\(\d+\)$"), x => reflector.Divide(x)},
};
Console.WriteLine("I am ready!");
while (true)
{
    var command = Console.ReadLine();

    foreach (var (regex, action) in operations)
    {
        var match = regex.Match(command);
        if (match.Success)
        {
            var value = command.Split('(')[1].Split(')')[0];
            action(int.Parse(value));
            Console.WriteLine(reflector.GetValue());
        }
    }
}
