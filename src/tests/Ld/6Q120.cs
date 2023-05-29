using System.Collections.Generic;
using System.Xml.Linq;

namespace Application
{
    class Task2
    {
        class Node<T>
        {
            public Node(T data)
            {
                Data = data;
            }

            public T Data { get; set; }

            public Node<T>? Next { get; set; }
        }

        class MyLinkedList<T>
        {
            public Node<T> head = new Node<T>(default(T));

            public MyLinkedList(List<T> list)
            {
                Node<T> last = head;
                foreach (T val in list)
                {
                    last.Next = new Node<T>(val);
                    last = last.Next;
                }
            }

            public static Node<T>? getFirstSameNode(MyLinkedList<T> linkedList1, MyLinkedList<T> linkedList2)
            {
                var h = linkedList1.head;
                var len1 = 0;
                while (h.Next != null)
                {
                    len1++;
                    h = h.Next;
                }
                var h2 = linkedList2.head;
                var len2 = 0;
                while (h2.Next != null)
                {
                    len2++;
                    h2 = h2.Next;
                }
                if (h != h2)
                    return null;

                h = linkedList1.head;
                h2 = linkedList2.head;
                for (int i = 0; i < len2-len1; i++)
                {
                    h2 = h2!.Next;
                }
                for (int i = 0; i < len1 - len2; i++)
                {
                    h = h!.Next;
                }

                while (h != null || h2 != null)
                {
                    if (h == h2)
                        return h;
                    h = h!.Next;
                    h2 = h2!.Next;
                }
                return null;
            }
        }

        static int Main()
        {
            var list1 = new List<string> { "one", "two", "three" };
            var list2 = new List<string> { "zero" };

            MyLinkedList<string> linkedList1 = new MyLinkedList<string>(list1);
            MyLinkedList<string> linkedList2 = new MyLinkedList<string>(list2);
            var h = linkedList1.head;
            var h2 = linkedList2.head;

            // comment this for check without same node
            while (h.Next != null)
            {
                h = h.Next;
            }
            while (h2.Next != null)
            {
                h2 = h2.Next;
            }
            var four = new Node<string>("four");
            h.Next = four;
            h2.Next = four;
            four.Next = new Node<string>("five");
            //

            h = linkedList1.head;
            while (h.Next != null)
            {
                h = h.Next;
                Console.WriteLine(h.Data);
            }
            Console.WriteLine();
            h2 = linkedList2.head;
            while (h2.Next != null)
            {
                h2 = h2.Next;
                Console.WriteLine(h2.Data);
            }
            Console.WriteLine();
            Console.WriteLine();

            var node = MyLinkedList<string>.getFirstSameNode(linkedList1, linkedList2);
            if (node != null)
            {
                Console.WriteLine(node.Data);
            }
            else
            {
                Console.WriteLine("null");
            }
            return 0;
        }
    }
}
