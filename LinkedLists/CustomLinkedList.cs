namespace LinkedLists;

public sealed class CustomLinkedList<T>
{
    public void AddFirst(T data)
    {
        var newNode = new Node<T>(data) { Next = Head };
        Head = newNode;
        Size++;
    }

    public Node<T> Head { get; private set; } = null!;
    public int Size;

    // ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
    public void AddToEnd(T data)
    {
        if (Head == null)
            Head = new Node<T>(data);
        else
        {
            var node = Head;
            while (node.Next != null)
                node = node.Next;
            var newNode = new Node<T>(data);
            node.Next = newNode;
        }
        Size++;
    }

    public Node<T> GetMid()
    {
        var count = 0;
        var mid = Size / 2;
        var node = Head;
        while (count != mid)
        {
            node = node.Next;
            count++;
        }
        return node;
    }

    public Node<T> GetAt(int index)
    {
        var count = 0;
        var node = Head;
        while (count != index)
        {
            node = node.Next;
            count++;
        }
        return node;
    }

    public void RemoveAt(int index)
    {
        var currentNode = Head.Next;
        var previousNode = Head;
        var count = 0;
        while (count != index)
        {
            currentNode = currentNode.Next;
            if (count != index - 1)
                previousNode = previousNode.Next;
            count++;
        }
        previousNode.Next = currentNode;
    }

    public void AddAt(int index, T data)
    {
        if (index == 0)
            AddFirst(data);
        else if (index == Size)
            AddToEnd(data);
        else if (index > Size)
            throw new IndexOutOfRangeException();
        else
            UpdateList(index, data);
    }

    private void UpdateList(int index, T data)
    {
        var currentNode = Head.Next;
        var previousNode = Head;
        var count = 1;
        while (count != index)
        {
            currentNode = currentNode.Next;
            previousNode = currentNode;
            count++;
        }
        previousNode.Next = new Node<T>(data) { Next = currentNode };
        Size++;
    }
}