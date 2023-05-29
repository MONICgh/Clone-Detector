
namespace task1
{
    class Program
    {
        public static void Main(string[] args)
        {
            var table = new HashTable<string, string>();
            table.Add("a", "Ivanov");
            table.Add("b", "Sidorov");
            
            Console.WriteLine(table); // {a: Ivanov, b: Sidorov}

            table.Delete("b");
            table.Add("a", "Danilov");
            Console.WriteLine(table); // {a: Danilov}

            Console.WriteLine(table.Find("a")); // Danilov
            //Console.WriteLine(table.Find("b")); // System.Collections.Generic.KeyNotFoundException: "No such key in the table"

        }
    }
}
    
