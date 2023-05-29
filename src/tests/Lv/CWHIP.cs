using System.Collections.Generic;
using System.Linq;

namespace task1
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
        public static string ConcatenateBy(List<MyElement> elements, char delimeter)
        {
            return elements.Count switch
            {
                <= 3 => "List should contain at least 4 elements",
                _ => string.Join(delimeter, elements.Skip(3).Select(elem => elem.Name)),
            };
        }
    }
   
   
   
}
