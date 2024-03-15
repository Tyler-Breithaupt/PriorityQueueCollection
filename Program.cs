namespace PriorityQueueCollection;

class Program
{
    static void Main(string[] args)
    {
        PriorityQueue<int> priorityQueue = new PriorityQueue<int>();

        // Add 5 items with different priorities
        priorityQueue.Enqueue(10, 3); // Priority 3
        priorityQueue.Enqueue(20, 2); // Priority 2
        priorityQueue.Enqueue(30, 5); // Priority 5
        priorityQueue.Enqueue(40, 1); // Priority 1
        priorityQueue.Enqueue(50, 4); // Priority 4

        // Display and remove items from the priority queue
        while (priorityQueue.Count > 0)
        {
            int highestPriorityItem = priorityQueue.Dequeue();
            Console.WriteLine("Highest Priority Item: " + highestPriorityItem);
        }
    }
}

public class PriorityQueue<T>
{
    private SortedList<int, Queue<T>> _sortedList = new SortedList<int, Queue<T>>();

    public int Count { get; private set; } = 0;

    public void Enqueue(T item, int priority)
    {
        if (!_sortedList.ContainsKey(priority))
        {
            _sortedList[priority] = new Queue<T>();
        }
        _sortedList[priority].Enqueue(item);
        Count++;
    }

    public T Dequeue()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Priority queue is empty");
        }

        // Get the queue with the highest priority
        var highestPriorityQueue = _sortedList.First();
        var item = highestPriorityQueue.Value.Dequeue();
        if (highestPriorityQueue.Value.Count == 0)
        {
            _sortedList.RemoveAt(0);
        }
        Count--;
        return item;
    }
}

