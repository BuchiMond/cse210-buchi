using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;

        int totalPoints = _points;

        if (_amountCompleted == _target)
        {
            totalPoints += _bonus;
            Console.WriteLine(
                $"Great work! You completed '{_shortName}' {_amountCompleted}/{_target} times " +
                $"and earned {_points} + bonus {_bonus} = {totalPoints} points!");
        }
        else if (_amountCompleted < _target)
        {
            Console.WriteLine(
                $"Nice! You recorded '{_shortName}' {_amountCompleted}/{_target} times " +
                $"and earned {_points} points.");
        }
        else
        {
            // After reaching the target, still award normal points only
            Console.WriteLine(
                $"You recorded '{_shortName}' again (already complete). " +
                $"You earned {_points} more points.");
        }

        return totalPoints;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        // Show progress: e.g. "Temple visits (Attend 10 times) -- Currently completed 2/10"
        return $"{_shortName} ({_description}) -- Currently completed {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        // Format: ChecklistGoal:name|description|points|amountCompleted|target|bonus
        return $"ChecklistGoal:{_shortName}|{_description}|{_points}|{_amountCompleted}|{_target}|{_bonus}";
    }
}
