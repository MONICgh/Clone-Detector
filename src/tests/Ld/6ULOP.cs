namespace task2
{
    class Program
    {
        public static Node<T> GetFirstMatch<T>(MyLinkedList<T> list1, MyLinkedList<T> list2)
        {
            int length1 = list1.GetLength();
            int length2 = list2.GetLength();
            int minLength = Math.Min(length1, length2);

            var cur1 = list1.Head;
            var cur2 = list2.Head;

            for (int i = 0; i <= length1 - minLength; i++)
            {
                cur1 = cur1.Next;
            }
            for (int i = 0; i <= length2 - minLength; i++)
            {
                cur2 = cur2.Next;
            }
            
            while (cur1 != null && !(cur1.Value.Equals(cur2.Value)))
            {
                cur1 = cur1.Next;
                cur2 = cur2.Next;
            }

            return cur1;
        }
        public static void Main(string[] args)
        {
            var list1 = new MyLinkedList<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list1.Add(4);
            list1.Add(5);

            var list2 = new MyLinkedList<int>();
            list2.Add(4);
            list2.Add(5);

            Console.WriteLine(GetFirstMatch<int>(list1, list2).Value); //4


        }
    }
}
