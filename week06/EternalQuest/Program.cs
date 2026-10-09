using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity: I added a level system based on the player's score.
        // As the player earns more points, the player's level increases.
        // This gives the program an extra reward beyond simply tracking points.

        GoalManager manager = new GoalManager();

        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("Eternal Quest");
            Console.WriteLine();
            Console.WriteLine($"Score: {manager.GetScore()}");
            Console.WriteLine($"Level: {manager.GetLevel()}");
            Console.WriteLine();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Show Score");
            Console.WriteLine("  7. Quit");
            Console.WriteLine();

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateGoal(manager);
            }
            else if (choice == "2")
            {
                Console.Clear();

                manager.DisplayGoals();

                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
            }
            else if (choice == "3")
            {
                manager.SaveGoals("goals.txt");

                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
            }
            else if (choice == "4")
            {
                manager.LoadGoals("goals.txt");

                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
            }
            else if (choice == "5")
            {
                RecordGoalEvent(manager);
            }
            else if (choice == "6")
            {
                Console.Clear();

                manager.DisplayScore();

                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
            }
            else if (choice == "7")
            {
                running = false;

                Console.WriteLine();
                Console.WriteLine("Thank you for using Eternal Quest!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid choice. Please select 1-7.");
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.Clear();

        Console.WriteLine("Create New Goal");
        Console.WriteLine();

        Console.WriteLine("Goal Types:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine();

        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        if (type != "1" && type != "2" && type != "3")
        {
            Console.WriteLine();
            Console.WriteLine("Invalid goal type.");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = GetIntegerInput();

        if (type == "1")
        {
            SimpleGoal goal = new SimpleGoal(
                name,
                description,
                points
            );

            manager.AddGoal(goal);

            Console.WriteLine();
            Console.WriteLine("Simple goal created.");
        }
        else if (type == "2")
        {
            EternalGoal goal = new EternalGoal(
                name,
                description,
                points
            );

            manager.AddGoal(goal);

            Console.WriteLine();
            Console.WriteLine("Eternal goal created.");
        }
        else if (type == "3")
        {
            Console.WriteLine();

            Console.Write("How many times does this goal need to be completed? ");
            int target = GetIntegerInput();

            Console.Write("What is the bonus for completing the target? ");
            int bonus = GetIntegerInput();

            ChecklistGoal goal = new ChecklistGoal(
                name,
                description,
                points,
                target,
                bonus
            );

            manager.AddGoal(goal);

            Console.WriteLine();
            Console.WriteLine("Checklist goal created.");
            Console.WriteLine(
                $"You will earn {points} points for each completion and {bonus} bonus points when you reach {target} completions."
            );
        }

        Console.WriteLine();
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }

    static void RecordGoalEvent(GoalManager manager)
    {
        Console.Clear();

        manager.DisplayGoals();

        Console.WriteLine();

        Console.Write("Which goal did you accomplish? ");
        int goalNumber = GetIntegerInput();

        Console.WriteLine();

        manager.RecordEvent(goalNumber);

        Console.WriteLine();
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }

    static int GetIntegerInput()
    {
        while (true)
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number) && number >= 0)
            {
                return number;
            }

            Console.Write("Please enter a valid number: ");
        }
    }
}