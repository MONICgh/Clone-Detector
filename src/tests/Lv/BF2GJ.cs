using System.Linq;
namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<MyElement>{
                new MyElement("Anna"),
                new MyElement("Zhanna"),
                new MyElement("Snezhana"),
                new MyElement("Oil"),
                new MyElement("Coil"),
                new MyElement("Iron"),

            };
            Console.WriteLine(MyElementMethods.ConcatenateBy(list, '$')); //Oil$Coil$Iron'
        }
    }
}
