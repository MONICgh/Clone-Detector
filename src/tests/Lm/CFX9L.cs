namespace LinkedList
{
    public class Node<T>
    {
        public T Data { get; }
        public Node<T>? Next { set; get; } = null;

        public Node(T _data)
        {
            Data = _data;
        }
    }
}
