namespace LinkedLists;

public class Node<T>
{
    public Node(T node)
    {
        Data = node;
        Next = null!;
    }

    public Node<T> Next;
    public readonly T Data;
}