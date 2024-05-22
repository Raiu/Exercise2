using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Exercise2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Run();
    }

    private static void Run()
    {
        PrintWelcomeMessage();
        PrintUsage();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nEnter your command:");

            string? command = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(command))
            {
                Console.WriteLine("Error: Invalid input");
                PrintUsage();
                continue;
            }

            switch (command.ToLower())
            {
                case "0":
                case "quit":
                case "exit":
                    running = false;
                    break;
                case "1":
                    Cinema cinema = new();
                    cinema.Run();
                    break;
                case "2":
                    //PrintEmployees();
                    break;
                case "?":
                case "help":
                    //PrintHelp();
                    break;
                default:
                    Console.WriteLine($"{command} is an invalid command");
                    break;
            }
        }
    }

    private static void PrintUsage()
    {
        StringBuilder sb = new();
        sb.AppendLine("\nCommands:");
        sb.AppendLine("   1             Cinema");
        sb.AppendLine("   2             Print all employees");  
        sb.AppendLine("   0 || quit     Quit");
        sb.AppendLine("   ? || help     Print help and usage");
        Console.WriteLine(sb.ToString());
    }

    private static void PrintWelcomeMessage()
    {
        StringBuilder sb = new();
        Console.WriteLine(sb.ToString());
    }
}
