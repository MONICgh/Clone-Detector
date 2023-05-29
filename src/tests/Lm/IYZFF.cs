namespace MyLinkedList;

public class Node<T>
{
    public T Value { get; }
    public Node<T>? Next { get; set; }
    public Node<T>? Prev { get; set; }

    public Node(T value, Node<T>? next = null, Node<T>? prev = null)
    {
        Value = value;
        Next = next;
        Prev = prev;
    }
}