using System;
using System.Collections.Concurrent;

internal class Program
{
    private static ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
    private static CancellationTokenSource cts = new CancellationTokenSource();
    private static Random random;
    private static void Main(string[] args)
    {
        random = new Random();
        var producerTask = Task.Run(() => Producer(cts.Token));
        var consumerTask = Task.Run(() => Consumer(cts.Token));

        Console.WriteLine("Press any key to stop...");
        Console.ReadKey();
        cts.Cancel();

        Task.WaitAll(producerTask, consumerTask);
        Console.WriteLine("Task completed. Exiting...");
    }

    public static void Producer(CancellationToken token)
    {
        int counter = 0;
        while (!token.IsCancellationRequested)
        {
            counter ++;
            queue.Enqueue(counter);
            Console.WriteLine($"Enqueue: {counter}");
            Thread.Sleep(random.Next(1000, 5000));
        }
    }
    
    public static void Consumer(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            if (queue.TryDequeue(out int item))
            {
                Console.WriteLine($"\tDequeue: {item}");
            }
            else
            {
                Console.WriteLine("Queue is empty...");
            }
            Thread.Sleep(random.Next(1000, 5000));
        }
    }
}