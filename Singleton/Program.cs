using System;
using System.Collections.Generic;
using System.Linq;

public class Servers
{
    
    private static readonly Lazy<Servers> instance = new Lazy<Servers>(() => new Servers());

   
    public static Servers Instance => instance.Value;

  
    private readonly HashSet<string> servers = new HashSet<string>();

  
    private Servers() { }

   
    public bool AddServer(string address)
    {
        // Проверка условия 1.2
        if (address.StartsWith("http://") || address.StartsWith("https://"))
        {
            // Проверка условия 1.3 
            return servers.Add(address);
        }
        return false; // Не добавляется, если не удовлетворяет условию 1.2
    }

    // список серверов начинающихся с http
    public IEnumerable<string> GetHttpServers()
    {
       
        return servers.Where(s => s.StartsWith("http://")).ToList();
    }

    // список серверов начинающихся с https
    public IEnumerable<string> GetHttpsServers()
    {
        // Условие 3
        return servers.Where(s => s.StartsWith("https://")).ToList();
    }
}


public class Program
{
    public static void Main()
    {
     
        var servers = Servers.Instance;
        
        Console.WriteLine(servers.AddServer("http://sss.com")); 
        Console.WriteLine(servers.AddServer("https://secssfaudfsfdse.com")); 
        Console.WriteLine(servers.AddServer("ftp://servers.com"));    
        Console.WriteLine(servers.AddServer("http://sss.com")); 

        
        Console.WriteLine("HTTP Servers:");
        foreach (var server in servers.GetHttpServers()) // Условие 2
        {
            Console.WriteLine(server);
        }

        Console.WriteLine("HTTPS Servers:");
        foreach (var server in servers.GetHttpsServers()) // Условие 3
        {
            Console.WriteLine(server);
        }
    }
}
