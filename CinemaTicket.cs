namespace Exercise2;

public class CinemaTicket
{
    private static Dictionary<string, int> _ticketPrices = new()
    {
        {"child", Config.TicketPriceChild},
        {"minor", Config.TicketPriceTeen},
        {"adult", Config.TicketPriceAdult},
        {"senior", Config.TicketPriceSenior},
        {"supersenior", Config.TicketPriceSuperSenior}
    };
    public int Price { get; private set; }

    public CinemaTicket(string ageGroup)
    {
        Price = _ticketPrices[ageGroup];
    }

    public CinemaTicket(int age)
    {
        Price = _ticketPrices[new Customer(age).AgeGroup];
    }
}
