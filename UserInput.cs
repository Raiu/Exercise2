namespace Exercise2;

public static class UserInput
{
    // private static int _attempts = 5;

    // public static int Int()
    // {
    //     throw NotImplementedException;
    // }

    public static string String()
    {
        int attempts = 0;
        while (true)
        {
            if (attempts > Config.UserInputAttempts) {
                Console.WriteLine("Too many attempts!");
                return "-1";
            }
            attempts++;

            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            Console.WriteLine("Please enter a string");
        }
    }
}
