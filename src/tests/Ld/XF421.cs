namespace TwoList
{
    public class Node<T>
    {
        private T data;
        private Node<T> next;
        
        public Node(T _data, Node<T> _next)
        {
            data = _data;
            next = _next;
        }

        public Node<T> Next()
        {
            return next;
        }
    }

    public class LinkedList<T>
    {
        private Node<T> head;
        
        public LinkedList(Node<T> _head)
        {
            head = _head;
        }

        public Node<T> Head()
        {
            return head;
        }

        public int Length()
        {
            int len = 0;
            Node<T> cur = head;
            while (cur != null)
            {
                len++;
                cur = cur.Next();
            }
            return len;
        }

        public static Node<T> FindIntersection(LinkedList<T> listA, LinkedList<T> listB)
        {
            int lenA = listA.Length();
            int lenB = listB.Length();

            Node<T> nodeA = listA.Head();
            Node<T> nodeB = listB.Head();
            for (int i = 1; i <= lenA - lenB; i++)
            {
                nodeA = nodeA.Next();
            }
            for (int i = 1; i <= lenB - lenA; i++)
            {
                nodeB = nodeB.Next();
            }

            while (nodeA != nodeB)
            {
                nodeA = nodeA.Next();
                nodeB = nodeB.Next();
            }
            return nodeA;
        }
    }
}