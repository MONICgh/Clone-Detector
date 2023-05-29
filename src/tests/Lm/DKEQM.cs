namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var myList = new MyLinkedList<int>();
            myList.Add(1);
            myList.Add(2);
            Console.WriteLine($"List elements: {myList.Count}"); //List elements: 2
            foreach (int item in myList)
            {
                Console.Write(item + " "); //1 2
            }
            Console.WriteLine();

            myList.Add(3);
            myList.Add(5);
            myList.Add(3);
            Console.WriteLine(myList.Remove(4)); //False
            Console.WriteLine(myList.Remove(3)); //True
            foreach (int item in myList)
            {
                Console.Write(item + " "); //1 2 5 3
            }
        }
    }
}