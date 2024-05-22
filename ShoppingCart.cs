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
}
