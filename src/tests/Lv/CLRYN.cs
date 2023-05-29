using System.Diagnostics;
using Task1;

string Drop3AndConcat(IEnumerable<Element> elements, char delimiter)
{
    return elements
        .Skip(3)
        .Select(el => el.Name)
        .Aggregate("", (acc, el) => acc.Equals("") ? el : acc + delimiter + el);
}

var list1 = new List<Element>
{
    new Element("A"),
    new Element("B")
};

var list2 = new List<Element>
{
    new Element("A"),
    new Element("B"),
    new Element("C"),
    new Element("D"),
    new Element("E")
};

Debug.Assert(Drop3AndConcat(list1, ',') == "");
Debug.Assert(Drop3AndConcat(list2, ';') == "D;E");

Console.WriteLine("All is Okay!");