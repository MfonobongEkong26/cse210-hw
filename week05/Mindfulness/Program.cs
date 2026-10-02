using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Creativity: The program keeps track of how many times
        // each mindfulness activity is completed during the session.
        int breathingCount = 0;
        int reflectionCount = 0;
        int listingCount = 0;

        while (true)
        {
            Console.Clear();

            Console.WriteLine("Mindfulness Program");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Show activity statistics");
            Console.WriteLine("  5. Quit");
            Console.WriteLine();
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
                breathingCount++;

                PauseBeforeMenu();
            }
            else if (choice == "2")
            {
                ReflectionActivity activity = new ReflectionActivity();
                activity.Run();
                reflectionCount++;

                PauseBeforeMenu();
            }
            else if (choice == "3")
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();
                listingCount++;

                PauseBeforeMenu();
            }
            else if (choice == "4")
            {
                Console.Clear();

                Console.WriteLine("Activity Statistics");
                Console.WriteLine();
                Console.WriteLine($"Breathing activities completed: {breathingCount}");
                Console.WriteLine($"Reflection activities completed: {reflectionCount}");
                Console.WriteLine($"Listing activities completed: {listingCount}");
                Console.WriteLine(
                    $"Total activities completed: {breathingCount + reflectionCount + listingCount}"
                );

                Console.WriteLine();
                Console.WriteLine("Press Enter to return to the menu.");
                Console.ReadLine();
            }
            else if (choice == "5")
            {
                Console.WriteLine();
                Console.WriteLine("Thank you for using the Mindfulness Program!");
                break;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid choice. Please select 1, 2, 3, 4, or 5.");
                Thread.Sleep(2000);
            }
        }
    }

    static void PauseBeforeMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Returning to the menu...");
        Thread.Sleep(2000);
    }
}