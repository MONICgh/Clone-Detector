namespace LinkedListTask
{
    public class Node
    {
        private int data;
        public Node next;

        public Node(int x)
        {
            data = x;
            next = null;
        }
    }
    
    public class MyLinkedList
    {
        private Node begin;
        private Node end;

        public MyLinkedList()
        {
            begin = null;
            end = null;
        }

        public Node Begin()
        {
            return begin;
        }

        public Node End()
        {
            return end;
        }

        public void Insert(int x)
        {
            var n = new Node(x);
            if (begin == null)
            {
                begin = n;
                end = n;
            }
            else
            {
                end.next = n;
                end = n;
            }
        }
    }
}