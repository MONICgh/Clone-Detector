using Task3;

var strings = new List<string> { "12345678", "1234567", "12", "12345", "123", "1", "123456789", "54321" };

SortToConsole.Apply(strings);

Console.WriteLine();

var sorted = SortToList.Apply(strings);
foreach (var s in sorted)
{
    Console.WriteLine(s);
}
