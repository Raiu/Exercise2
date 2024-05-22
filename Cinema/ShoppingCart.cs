using System.Diagnostics;

namespace Exercise2;

public class ShoppingCart
{
    private List<CinemaTicket> _tickets = new();
    
    public void AddTicket(CinemaTicket ticket)
    {
        _tickets.Add(ticket);
    }

    public void AddTicket(int age)
    {
        _tickets.Add(new CinemaTicket(age));
    }

    public List<CinemaTicket> GetTickets()
    {
        return _tickets;
    }

    public int GetTotalPrice()
    {
        int totalPrice = 0;
        foreach (var ticket in _tickets)
        {
            totalPrice += ticket.Price;
        }
        return totalPrice;
    }

    public int GetTotalTickets()
    {
        return _tickets.Count;
    }

    public void SummarizeCart()
    {
        Console.WriteLine("\n\nCart summary: \n");
        foreach (var ticket in _tickets)
        {
            string ticketPrice = string.Format(Config.Culture, "{0:C0}", ticket.Price);
            Console.WriteLine($"{ticket.AgeGroup} - {ticketPrice}kr");
        }

        Console.WriteLine($"\nTotal tickets: {GetTotalTickets()}");
        string totPrice = string.Format(Config.Culture, "{0:C0}", GetTotalPrice());
        Console.WriteLine($"\nTotal price: {totPrice}");
        
    }
}