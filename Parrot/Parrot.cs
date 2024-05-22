
using System.Text;

namespace Exercise2;

public class Parrot
{
    internal void Run()
    {
        StringBuilder sb = new();
        sb.AppendLine("Welcome to the Parrot game");
        sb.AppendLine("You will enter word and ill nag you with it 10 times, ");
        sb.AppendLine("just like a parrot");
        sb.AppendLine("---------------------------");
        sb.AppendLine("Please enter your word: ");
        Console.WriteLine(sb);

        string input = UserInput.String();
        if (input == "-1")
        {
            Console.WriteLine("Returning to main menu");
            return;
        }
        Console.Write("\n\n");

        StringBuilder sb1 = new();
        StringBuilder sb2 = new();

        for (int i = 0; i < 10; i++)
        {
            sb1.Append(input);
            sb2.Append($"{i+1}. {input}{(i==9 ? "" : ", " )}");
            Console.Write($"{i + 1}. {input}{(i == 9 ? "" : ", ")}");
        }
        Console.Write("\n\n");

        Console.WriteLine(sb1 + "\n");

        Console.WriteLine(sb2 + "\n");        

        Console.WriteLine("\n\nWas it not fun?!\n\nokay... Returning to main menu");
    }
}
