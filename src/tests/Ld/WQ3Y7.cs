using System.Runtime.Remoting.Messaging;

namespace HW_03
{
    public class Node<T>
    {
        public Node(T value, Node<T> next)
        {
            Value = value;
            Next = next;
        }

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
        public Node<T> Next { get; }
        public T Value { get; }
    }

}
