using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("==== Eternal Quest ====");
            Console.WriteLine($"Current Score: {_score}");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please pick 1–6.");
                    break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("Which type of goal would you like to create?");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Progress Goal (large goal with gradual progress)");
        Console.WriteLine("5. Negative Goal (lose points for bad habits)");
        Console.Write("Enter choice: ");
        string typeChoice = Console.ReadLine();

        Console.Write("Enter short name of the goal: ");
        string name = Console.ReadLine();

        Console.Write("Enter a description: ");
        string description = Console.ReadLine();

        // Negative goals have a “penalty” instead of “points gained”
        int points = 0;
        if (typeChoice != "5")
        {
            Console.Write("Enter the points for each completion: ");
            points = int.Parse(Console.ReadLine());
        }

        if (typeChoice == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (typeChoice == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (typeChoice == "3")
        {
            Console.Write("How many times does this goal need to be completed? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for completing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        else if (typeChoice == "4")
        {
            Console.Write("What is the total target amount for this goal? (for example, 42 for 42 km): ");
            double targetAmount = double.Parse(Console.ReadLine());

            Console.Write("What is the bonus for reaching the full target? ");
            int bonus = int.Parse(Console.ReadLine());

            // Current progress starts at 0
            _goals.Add(new ProgressGoal(name, description, points, 0.0, targetAmount, bonus));
        }
        else if (typeChoice == "5")
        {
            Console.Write("How many points should be LOST each time this bad habit is recorded? ");
            int penalty = int.Parse(Console.ReadLine());

            _goals.Add(new NegativeGoal(name, description, penalty, 0));
        }
        else
        {
            Console.WriteLine("Unknown type. Goal not created.");
        }
    }

    private void ListGoals()
    {
        Console.WriteLine("Your Goals:");
        if (_goals.Count == 0)
        {
            Console.WriteLine(" (no goals yet)");
            return;
        }

        int index = 1;
        foreach (Goal goal in _goals)
        {
            string status = goal.IsComplete() ? "[X]" : "[ ]";
            Console.WriteLine($"{index}. {status} {goal.GetDetailsString()}");
            index++;
        }
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals to record. Create one first.");
            return;
        }

        Console.WriteLine("Select the goal you accomplished (or failed, for negative goals):");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.Write("Enter goal number: ");
        if (int.TryParse(Console.ReadLine(), out int goalIndex))
        {
            goalIndex--; // convert to 0-based
            if (goalIndex >= 0 && goalIndex < _goals.Count)
            {
                int pointsEarned = _goals[goalIndex].RecordEvent();
                _score += pointsEarned;
                Console.WriteLine($"You now have {_score} total points.");
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid number.");
        }
    }

    private void SaveGoals()
    {
        Console.Write("Enter a filename to save to (for example: goals.txt): ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            // First line: score
            writer.WriteLine(_score);

            // Next lines: each goal representation
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals and score saved successfully.");
    }

    private void LoadGoals()
    {
        Console.Write("Enter the filename to load from: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();

        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0)
        {
            Console.WriteLine("File is empty.");
            return;
        }

        // First line is the score
        _score = int.Parse(lines[0]);

        // Other lines are goals
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] typeAndData = line.Split(':');
            string type = typeAndData[0];
            string data = typeAndData[1];

            string[] parts = data.Split('|');

            if (type == "SimpleGoal")
            {
                string name = parts[0];
                string description = parts[1];
                int points = int.Parse(parts[2]);
                bool isComplete = bool.Parse(parts[3]);

                SimpleGoal g = new SimpleGoal(name, description, points);

                // set completion using reflection (keeps field private but restores state)
                typeof(SimpleGoal)
                    .GetField("_isComplete", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    .SetValue(g, isComplete);

                _goals.Add(g);
            }
            else if (type == "EternalGoal")
            {
                string name = parts[0];
                string description = parts[1];
                int points = int.Parse(parts[2]);
                _goals.Add(new EternalGoal(name, description, points));
            }
            else if (type == "ChecklistGoal")
            {
                string name = parts[0];
                string description = parts[1];
                int points = int.Parse(parts[2]);
                int amountCompleted = int.Parse(parts[3]);
                int target = int.Parse(parts[4]);
                int bonus = int.Parse(parts[5]);

                ChecklistGoal g = new ChecklistGoal(name, description, points, target, bonus);

                typeof(ChecklistGoal)
                    .GetField("_amountCompleted", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    .SetValue(g, amountCompleted);

                _goals.Add(g);
            }
            else if (type == "ProgressGoal")
            {
                string name = parts[0];
                string description = parts[1];
                int points = int.Parse(parts[2]);
                double current = double.Parse(parts[3]);
                double target = double.Parse(parts[4]);
                int bonus = int.Parse(parts[5]);

                ProgressGoal g = new ProgressGoal(name, description, points, current, target, bonus);
                _goals.Add(g);
            }
            else if (type == "NegativeGoal")
            {
                string name = parts[0];
                string description = parts[1];
                int penalty = int.Parse(parts[2]);
                int timesOccurred = int.Parse(parts[3]);

                NegativeGoal g = new NegativeGoal(name, description, penalty, timesOccurred);
                _goals.Add(g);
            }
        }

        Console.WriteLine("Goals and score loaded successfully.");
    }
}
