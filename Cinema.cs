using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Exercise2;

public class Cinema
{
    internal void Run()
    {
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
                    SingleTicketPriceInquiry();
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
    
    private void BuyTickets()
    {
        ShoppingCart cart = new();

        Console.WriteLine("You can either provide how many tickets you want to buy and ill help you furhter.");
        Console.WriteLine("Or you can use the command \"multi\" to buy multiple tickets.");
        Console.WriteLine("Example: multi 34 24 21 50 34");

        string command;
        string? input;
        int numberOfTickets = 0;
        int attempts = 0;
        while (true)
        {
            if (attempts > 5) {
                Console.WriteLine("Too many attempts!");
                return;
            }
            attempts++;

            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Error: Invalid input");
                PrintUsage();
                continue;
            }

            else if (int.TryParse(input, out numberOfTickets))
            {
                command = "wizard";
                break;
            }
            Console.WriteLine("Please enter a valid option");
        }
    }

    private static void SingleTicketPriceInquiry()
    {
        Console.WriteLine("Enter your age for a price estimation: ");
        int age;
        int attempts = 0;
        while (true)
        {
            if (attempts > 5) {
                Console.WriteLine("Too many attempts!\nReturning to main menu");
                return;
            }
            if (int.TryParse(Console.ReadLine(), out age))
            {
                break;
            }
            Console.WriteLine("Please enter a valid age");
            attempts++;
        }

        string ageGroup = new Customer(age).AgeGroup;
        // This is a bit redundant, but i wanted to play around with pipelines 
        int price = new CinemaTicket(new Customer(age).AgeGroup).Price;

        string article = (ageGroup == "adult") ? "an" : "a";
        string culturePrice = String.Format(Config.Culture, "{0:C0}", price);
        Console.WriteLine($"You are {article} {ageGroup}, so the ticket price will be {culturePrice}");

        return;
    }

    private static void PrintUsage()
    {
        StringBuilder sb = new();
        sb.AppendLine("\nCommands:");
        sb.AppendLine("   1             Single ticket price");
        sb.AppendLine("   2             Buy tickets");  
        sb.AppendLine("   0 || quit     Exit to Main menu");
        sb.AppendLine("   ? || help     Print help and usage");
        Console.WriteLine(sb.ToString());
    }
}
