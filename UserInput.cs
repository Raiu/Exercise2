namespace Exercise2;

public static class UserInput
{
    private static int _attempts = 5;

    public static int Int()
    {

    }

    public static int String()
    {
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Error: Invalid input");
            continue;
        }

    }

}
