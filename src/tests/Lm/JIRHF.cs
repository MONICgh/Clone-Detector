namespace MyLinkedList
{
    public class Node<T>
    {
        public T Data;
        public Node<T> Next;
        public Node<T> Previous;
        
        public Node(T data, Node<T> next = null, Node<T> previous = null)
        {
            Data = data;
            Next = next;
            Previous = previous;
        }
    }
}