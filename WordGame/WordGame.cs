using System.Text;
using System.Text.RegularExpressions;

namespace Exercise2;

public class WordGame
{
    private int _wordIndex;
    private static readonly Regex StripPattern = new(@"|[().,]");

    public WordGame()
    {
        _wordIndex = 3;    
    }

    public WordGame(int wordIndex)
    {
        _wordIndex = wordIndex;
    }

    public void Run()
    {
        StringBuilder sb = new();
        sb.AppendLine("Welcome to the WordGame");
        sb.AppendLine($"You will provide a lorem ipsum text and i'll find the {_wordIndex.DisplayWithSuffix()} word ");
        sb.AppendLine("for you. Magic!!!");
        sb.AppendLine("---------------------------");
        sb.AppendLine("Please enter your sentence: ");
        Console.WriteLine(sb);

        string[] splitInput;
        int iter = 0;
        do
        {
            string input = UserInput.String();
            if (input == "-1")
            {
                Console.WriteLine("Returning to main menu");
                return;
            }
            var cleanInput = StripPattern.Replace(input, "");
            splitInput = cleanInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (splitInput.Length >= _wordIndex)
            {
                break;
            }

            if (iter > Config.UserInputAttempts)
            {
                Console.WriteLine("Returning to main menu");
                return;
            }

            Console.WriteLine($"Please enter at least {_wordIndex} words");
            iter++;
        }
        while (true);

        var theWord = splitInput[_wordIndex - 1];
        Console.WriteLine($"The {_wordIndex.DisplayWithSuffix()} word is: {theWord}");

        Console.WriteLine("\n\nReturning to main menu");
        return;
    }
}
