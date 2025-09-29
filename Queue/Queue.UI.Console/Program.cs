using Queue.UI.Core;

var queue = new QueueUsingArray<int>(5);
var opc = "0";

do
{
    opc = Menu();
    switch (opc)
    {
        case "1":
			try
			{
				Console.WriteLine("Enter number: ");
				var number = int.Parse(Console.ReadLine()!);
				queue.Enqueue(number);
            }
			catch (Exception ex)
			{

				Console.WriteLine(ex.Message);
			}
			break;
		case "2":
			try
			{
				var item = queue.Dequeue();
				Console.WriteLine($"Item dequeued: {item}");
            }
			catch (Exception ex)
			{

				Console.WriteLine(ex.Message);
			}
			break;
		case "3":
			try
			{
                Console.WriteLine($"Item in Peek: {queue.Peek()}");
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.Message);
			}
			break;
    }
}while (opc != "0");
string Menu()
{
	Console.WriteLine("1: Enqueue");
	Console.WriteLine("2: Dequeue");
	Console.WriteLine("3: Peek");
	Console.WriteLine("0: Exit");
	return Console.ReadLine()!;
}