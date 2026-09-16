using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity: This program hides three random words at a time
        // to help the user practice memorizing the scripture.

        Reference reference = new Reference("Philippians", 4, 13);

        string text = "I can do all things through Christ which strengtheneth me.";

        Scripture scripture = new Scripture(reference, text);

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to continue or type 'quit' to finish: ");

            string input = Console.ReadLine();

            if (input != null && input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
    }
}