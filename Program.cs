using System.Collections;

/// You are developing a program to manage a call queue of customers using the Queue in C#.
/// The program creates a queue of callers and demonstrates the functionality of enqueueing
/// elements into the queue and iterating over the elements and dequeuing.
/// 
/// Use linked lists.
/// 

CallerQueue queue = new CallerQueue();
queue.Enqueue("Alpha");
queue.Enqueue("Bravo");
queue.Enqueue("Charlie");
queue.Enqueue("Delta");
queue.Enqueue("Echo");
queue.Dequeue();
queue.Enqueue("Foxtrot");

foreach(CallerNode node in queue)
{
    Console.WriteLine(node.ToString());
}


class CallerQueue: IEnumerable<CallerNode>
{
    private CallerNode Head { get; set; }
    private CallerNode Tail { get; set; }
    private int size;

    public CallerQueue()
    {
        size = 0;
        Head = null;
        Tail = null;
    }

    public void Enqueue(string newCaller)
    {
        CallerNode newNode = new CallerNode(newCaller, null);
        if(size==0)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            Tail.Next = newNode;
            Tail = Tail.Next;
        }
        size++;
    }
    public CallerNode Dequeue()
    {
        CallerNode output = Head;
        if(Head==null)
        {
            Console.WriteLine("Queue empty.");
            return null;
        }
        Head = Head.Next;
        size--;
        return output;
    }

    public IEnumerator<CallerNode> GetEnumerator()
    {
        return new CallerQueueEnumerator(Head);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    private class CallerQueueEnumerator : IEnumerator<CallerNode>
    {
        private CallerNode Current;
        private CallerNode Head;
        
        public CallerQueueEnumerator(CallerNode head)
        {
            Head = head;
            Current = null;
        }

        CallerNode IEnumerator<CallerNode>.Current => Current;

        object IEnumerator.Current => Current;

        public void Dispose() {}

        public bool MoveNext()
        {
            if (Current == null) { Current = Head; }
            else { Current = Current.Next; }
            return Current != null;
        }

        public void Reset()
        {
            Current = Head;
        }
    }
}

class CallerNode
{
    public string Caller;
    public CallerNode Next;

    public CallerNode(string caller, CallerNode next)
    {
        Caller = caller;
        Next = next;
    }
    public override string ToString()
    {;
        return $"{Caller}";
    }
}
