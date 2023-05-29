using System.Collections.Generic;
using System.Linq;


namespace task2
{
    class MyElement
    {
        public string Name { get; set; }

        public MyElement(string name)
        {
            Name = name;
        }
    }

    static class MyElementMethods
    {
        public static List<MyElement> IndexNameFilter(List<MyElement> elements)
        {
            return elements.Where((elem, index) => elem.Name.Length > index).ToList();
        }
    }

}
