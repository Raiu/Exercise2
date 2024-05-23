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
                    BuyTickets();
                    break;
                case "?":
                case "help":
                    PrintUsage();
                    break;
                default:
                    Console.WriteLine($"{command} is an invalid command");
                    break;
            }
        }
    }

    private void SingleTicketPriceInquiry()
    {
        Console.WriteLine("Enter your age for a price estimation: ");
        int age;
        int attempts = 0;
        while (true)
        {
            if (attempts > Config.UserInputAttempts) {
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
        string culturePrice = string.Format(Config.Culture, "{0:C0}", price);
        Console.WriteLine($"You are {article} {ageGroup}, so the ticket price will be {culturePrice}");

        return;
    }

    private void BuyTickets()
    {
        ShoppingCart cart = new();

        Console.WriteLine("You can either provide how many tickets you want to buy and ill help you furhter.");
        Console.WriteLine("Or you can use the command \"multi\" to buy multiple tickets.");
        Console.WriteLine("Usage:");
        Console.WriteLine("   [number-of-tickets]");
        Console.WriteLine("   multi <age1> <age2> ... <ageN>");

        var (command, argument) = RequestInputBuyTickets();
        if (command == "fail") return;

        if (command == "multi")
        {
            string[] ages = argument.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (string age in ages)
            {
                if (!int.TryParse(age, out int result))
                {
                    Console.WriteLine("multi contains invalid numbers");
                    return;
                }

                cart.AddTicket(result);
            }
        }
        else if (command == "wizard")
        {
            if (!int.TryParse(argument, out int result))
            {
                Console.WriteLine("invalid number for wizard");
                return;
            }
            List<CinemaTicket> tickets = WizardGenTickets(result);
            if (tickets.Count == 0) return;

            foreach (var ticket in tickets)
            {
                cart.AddTicket(ticket);
            }
        }

        cart.SummarizeCart();
        return;
    }

    private List<CinemaTicket> WizardGenTickets(int numberOfTickets)
    {
        Console.WriteLine("Please provide the age of each Cinema visitor:");
        bool error = false;
        List<CinemaTicket> tickets = new();
        for (int i = 0; i < numberOfTickets; i++)
        {
            Console.WriteLine("Enter age:");
            int age = RequestInputInt();
            
            if (age == -1) 
            {
                error = true;
                break;
            }

            tickets.Add(new CinemaTicket(age));
        }

        if (error) return new List<CinemaTicket>();

        return tickets;
    }

    private int RequestInputInt()
    {
        int attempts = 0;
        int result = 0;
        while (true)
        {
            if (attempts > Config.UserInputAttempts) {
                Console.WriteLine("Too many attempts!");
                result = -1;
                break;
            }
            attempts++;
            
            string? input = Console.ReadLine();
            if (int.TryParse(input, out result))
            {
                break;
            }
            Console.WriteLine("Please enter a valid number");
        }
        return result;
    }

    private (string, string) RequestInputBuyTickets()
    {
        string command = "fail";
        string argument = "";

        int attempts = 0;
        while (true)
        {
            if (attempts > 5) {
                Console.WriteLine("Too many attempts!");
                break;
            }
            attempts++;

            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Error: Invalid input");
                continue;
            }

            if (input.ToLower().StartsWith("multi"))
            {
                command = "multi";
                argument = input.ToLower().Replace("multi ", "").Trim();
                break;
            }
            else if (int.TryParse(input, out int result))
            {
                command = "wizard";
                argument = input;
                break;
            }

            Console.WriteLine("Please enter a valid option");
        }

        return (command, argument);
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
