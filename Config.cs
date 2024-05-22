using System.Globalization;

namespace Exercise2;

public static class Config
{
    public static readonly CultureInfo Culture = new("sv-SE");

    public const int TicketPriceChild       = 0;
    public const int TicketPriceTeen        = 80;
    public const int TicketPriceAdult       = 120;
    public const int TicketPriceSenior      = 90;
    public const int TicketPriceSuperSenior = 0;

    public const int ChildAgeCutOff         = 5;
    public const int TeenAgeCutOff          = 20;
    public const int SeniorAgeCutOff        = 65;
    public const int SuperSeniorAgeCutOff   = 99;
}
