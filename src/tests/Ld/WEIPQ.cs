namespace task2
{
    class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
        public Node (T value, Node<T> next)
        {
            Value = value;
            Next = next;
        }

       
    }
    class MyLinkedList<T>
    {
        public Node<T> Head;
        private Node<T> Tail;
        private int count;

        public MyLinkedList()
        {
            Head = new Node<T>(default);
            Tail = Head;
            count = 0;  
        }

        public void Add(T item)
        {
            var newNode = new Node<T>(item);
            Tail.Next = newNode;
            Tail =  newNode;    
            count++;
        }

        public void Remove(T item)
        {
            var cur = Head;
            int steps = 0;

            while (steps < count)
            {
                if (cur.Next.Value.Equals(item))
                {
                    cur.Next = cur.Next.Next;
                    count--;
                }
                cur = cur.Next;
                steps++;
            }
        }
        public int GetLength()
        {
            return count;
        }

        public void Clear()
        {
            Head.Next = null;
            Tail = Head;
            count = 0;
        }

        public override string ToString()
        {
            string outputString = "";
            var cur = Head;
            int steps = 0;

            while (steps < count)
            {
                cur = cur.Next;
                outputString += $"{cur.Value}, ";
                steps++;
            }

            if (outputString.Length > 0)
            {
                outputString = outputString.Remove(outputString.Length - 2, 2);
            }
            return "{" + outputString + "}";
  
        }
    }
}
