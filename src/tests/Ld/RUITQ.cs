namespace LinkedLists
{

    public class FirstCommonNodeFinder<T>
    {
        public Node<T>? Find(SingleLinkedList<T> list1, SingleLinkedList<T> list2)
        {
            var length1 = list1.Lengt;
            var length2 = list2.Lengt;

            while (length1 > length2)
            {
                list1.head = list1.head!.next;
                length1 -= 1;
            }

            while (length2 > length1)
            {
                list2.head = list2.head!.next;
                length2 -= 1;
            }

            while (list1.head != null && list2.head != null)
            {
                if (ReferenceEquals(list1.head, list2.head))
                {
                    return list1.head;
                }

                list1.head = list1.head!.next;
                list2.head = list2.head!.next;
            }

            return null;
        }
    }

    public class SingleLinkedList<T>
    {
        public Node<T>? head;

        public SingleLinkedList(Node<T>? node = null)
        {
            head = node;
        }

        public int Lengt
        {
            get
            {
                var currentNode = head;
                var length = 0;
                while (currentNode != null)
                {
                    length += 1;
                    currentNode = currentNode.next;
                }

                return length;
            }
        }
    }

    public class Node<T>
    {
        public T val;
        public Node<T> next;

        public Node(T data)
        {
            val = data;
            next = null;
        }
    }

}