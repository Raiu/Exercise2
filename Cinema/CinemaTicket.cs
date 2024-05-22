namespace Exercise2;

public class CinemaTicket
{
    private static Dictionary<string, int> _ticketPrices = new()
    {
        {"child", Config.TicketPriceChild},
        {"teen", Config.TicketPriceTeen},
        {"adult", Config.TicketPriceAdult},
        {"senior", Config.TicketPriceSenior},
        {"supersenior", Config.TicketPriceSuperSenior}
    };
    public int Price { get; private set; }

    public string AgeGroup { get; private set; }

    public CinemaTicket(string ageGroup)
    {
        Price = _ticketPrices[ageGroup];
        AgeGroup = ageGroup;
    }

    public CinemaTicket(int age)
    {
        string ageGroup = new Customer(age).AgeGroup;
        Price = _ticketPrices[ageGroup];
        AgeGroup = ageGroup;
    }
}
