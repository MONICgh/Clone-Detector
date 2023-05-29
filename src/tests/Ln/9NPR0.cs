namespace task1
{
    class Program
    {
        public static void Main(string[] args)
        {
            var table = new HashTable<int, string>();
            table.Add(1, "Vasya");
            table.Add(1, "Vasya");
            table.Add(1, "Kolya");
            table.Add(2, "Varya");
            Console.WriteLine(table); //{1: Vasya, 1: Kolya, 2: Varya}

            table.Delete(1);
            Console.WriteLine(table); // {2: Varya}

            var itemsList = table.Find(2); // Varya
            foreach (var item in itemsList)
            {
                Console.WriteLine(item);    
            }

        }
    }
}
