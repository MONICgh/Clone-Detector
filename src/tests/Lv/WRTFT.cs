using Task2;

IEnumerable<Element> fun(IEnumerable<Element> list)
{
    return list.Where(((element, index) => element.Name.Length > index));
}

Element[] elements =
{
    new ("This"), 
    new ("is"), 
    new ("a"), 
    new ("test"), 
    new ("sample")
};
foreach(var element in fun(elements)) {
    Console.WriteLine(element.Name);
}