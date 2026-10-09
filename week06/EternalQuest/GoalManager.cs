using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int goalNumber)
    {
        if (goalNumber < 1 || goalNumber > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal goal = _goals[goalNumber - 1];

        if (goal.IsComplete() && goal is SimpleGoal)
        {
            Console.WriteLine("This goal has already been completed.");
            return;
        }

        int pointsEarned = goal.RecordEvent();
        _score += pointsEarned;

        Console.WriteLine($"Congratulations! You earned {pointsEarned} points.");
        Console.WriteLine($"Your score is now {_score}.");
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Goals:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public int GetScore()
    {
        return _score;
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Your current score is: {_score}");
        Console.WriteLine($"Your current level is: {GetLevel()}");
    }

    public string GetLevel()
    {
        if (_score >= 2000)
        {
            return "5 - Master";
        }
        else if (_score >= 1000)
        {
            return "4 - Dedicated";
        }
        else if (_score >= 500)
        {
            return "3 - Faithful";
        }
        else if (_score >= 200)
        {
            return "2 - Growing";
        }
        else
        {
            return "1 - Beginner";
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("Save file was not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0)
        {
            return;
        }

        _goals.Clear();

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');

            string goalType = parts[0];
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);

            if (goalType == "SimpleGoal")
            {
                SimpleGoal goal = new SimpleGoal(name, description, points);

                bool isComplete = bool.Parse(parts[4]);
                goal.SetComplete(isComplete);

                _goals.Add(goal);
            }
            else if (goalType == "EternalGoal")
            {
                EternalGoal goal = new EternalGoal(name, description, points);

                _goals.Add(goal);
            }
            else if (goalType == "ChecklistGoal")
            {
                int target = int.Parse(parts[4]);
                int bonus = int.Parse(parts[5]);
                int amountCompleted = int.Parse(parts[6]);

                ChecklistGoal goal = new ChecklistGoal(
                    name,
                    description,
                    points,
                    target,
                    bonus
                );

                goal.SetAmountCompleted(amountCompleted);

                _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }
}