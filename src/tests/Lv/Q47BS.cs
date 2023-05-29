using System.Diagnostics;
using Task1;

IEnumerable<Element> NameLengthFilter(IEnumerable<Element> elements)
{
    return elements
        .Where((element, i) => element.Name.Length > i);
}

var list = new List<Element>
{
    new Element("A"),
    new Element("B"),
    new Element("CCC"),
    new Element("D")
};

var listFiltered = new List<Element>
{
    list[0],
    list[2]
};

Debug.Assert(NameLengthFilter(list).Count() == 2);

foreach (var (el1, el2) in NameLengthFilter(list).Zip(listFiltered))
{
    Debug.Assert(el1.Equals(el2));
}

Console.WriteLine("All is Okay!");