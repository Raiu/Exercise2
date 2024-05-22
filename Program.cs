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
        Run();
    }

    private static void Run()
    {
        PrintWelcomeMessage();

        bool running = true;
        while (running)
        {
            PrintUsage();

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
                    Parrot parrot = new();
                    parrot.Run();
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

    private static void PrintWelcomeMessage()
    {
        StringBuilder sb = new();
        sb.AppendLine("Welcome to Exercise 2!");
        Console.WriteLine(sb);
    }

    private static void PrintUsage()
    {
        StringBuilder sb = new();
        sb.AppendLine("\nCommands:");
        sb.AppendLine("   1             Cinema");
        sb.AppendLine("   2             Parrot game");
        sb.AppendLine("   3             3rd word game");
        sb.AppendLine("   0 || quit     Quit");
        sb.AppendLine("   ? || help     Print help and usage");
        Console.WriteLine(sb.ToString());
    }
}
