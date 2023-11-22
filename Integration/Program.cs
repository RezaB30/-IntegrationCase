using Integration.Service;
using System.ComponentModel;

namespace Integration;

public abstract class Program
{
    public static void Main(string[] args)
    {
        var service = new ItemIntegrationService();

        Console.WriteLine($"Adding \"a\" to queue.");
        ThreadPool.QueueUserWorkItem(_ => service.SaveItem("a"));
        Console.WriteLine($"Adding \"b\" to queue.");
        ThreadPool.QueueUserWorkItem(_ => service.SaveItem("b"));
        Console.WriteLine($"Adding \"c\" to queue.");
        ThreadPool.QueueUserWorkItem(_ => service.SaveItem("c"));

        // without wait it works
        //Thread.Sleep(500);

        Console.WriteLine($"Adding \"a\" to queue.");
        ThreadPool.QueueUserWorkItem(_ => service.SaveItem("a"));
        Console.WriteLine($"Adding \"b\" to queue.");
        ThreadPool.QueueUserWorkItem(_ => service.SaveItem("b"));
        Console.WriteLine($"Adding \"c\" to queue.");
        ThreadPool.QueueUserWorkItem(_ => service.SaveItem("c"));

        Thread.Sleep(5000);

        Console.WriteLine("Everything recorded:");

        service.GetAllItems().ForEach(Console.WriteLine);

        Console.ReadLine();
    }
}