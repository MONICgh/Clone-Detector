using Task1;

string fun(IEnumerable<Element> list, char delimiter)
{
    return list.Skip(3)
        .Select(element => element.Name)
        .Aggregate((partialString, name) => $"{partialString}{delimiter}{name}");
}

Element[] elements =
{
    new ("skip"), 
    new ("three"), 
    new ("words"), 
    new ("This"), 
    new ("is"), 
    new ("a"), 
    new ("test"), 
    new ("sample")
};
Console.WriteLine(fun(elements, ' '));
Console.WriteLine(fun(elements, ':'));
Console.WriteLine(fun(elements, '~'));
