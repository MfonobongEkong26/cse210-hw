using System;

class Program
{
    static void Main()
    {
        // Display the welcome message
        DisplayWelcome();

        // Get the user's name
        string name = PromptUserName();

        // Get the user's favorite number
        int number = PromptUserNumber();

        // Square the number
        int squaredNumber = SquareNumber(number);

        // Display the result
        DisplayResult(name, squaredNumber);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}