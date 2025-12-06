using System;

// ProgressGoal = large goal where you slowly make progress
// Example: "Run a marathon (42 km)" and you log how many km you ran each time.
public class ProgressGoal : Goal
{
    private double _currentAmount; // how much progress we have made so far
    private double _targetAmount;  // total amount needed
    private int _bonus;            // extra points when reaching target

    public ProgressGoal(string name, string description, int points,
                        double currentAmount, double targetAmount, int bonus)
        : base(name, description, points)
    {
        _currentAmount = currentAmount;
        _targetAmount = targetAmount;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        Console.Write(
            $"How much progress did you make for '{_shortName}' " +
            $"(for example, kilometers or percent)? ");
        double amount = double.Parse(Console.ReadLine());

        double before = _currentAmount;
        _currentAmount += amount;

        int totalPoints = _points;

        // If we crossed the target for the first time, add bonus.
        if (before < _targetAmount && _currentAmount >= _targetAmount)
        {
            totalPoints += _bonus;
            Console.WriteLine(
                $"Amazing! You reached the full target for '{_shortName}' " +
                $"and earned {_points} points + {_bonus} bonus = {totalPoints} points.");
        }
        else
        {
            Console.WriteLine(
                $"Great! You added {amount} progress to '{_shortName}'. " +
                $"Current progress: {_currentAmount}/{_targetAmount}. " +
                $"You earned {_points} points.");
        }

        return totalPoints;
    }

    public override bool IsComplete()
    {
        return _currentAmount >= _targetAmount;
    }

    public override string GetDetailsString()
    {
        return $"{_shortName} ({_description}) -- Progress: {_currentAmount}/{_targetAmount}";
    }

    public override string GetStringRepresentation()
    {
        // Format: ProgressGoal:name|description|points|current|target|bonus
        return $"ProgressGoal:{_shortName}|{_description}|{_points}|{_currentAmount}|{_targetAmount}|{_bonus}";
    }
}
