using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"Good job! You completed '{_shortName}' and earned {_points} points.");
            return _points;
        }
        else
        {
            Console.WriteLine($"This goal '{_shortName}' is already completed. No extra points.");
            return 0;
        }
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        // Format: SimpleGoal:name|description|points|isComplete
        return $"SimpleGoal:{_shortName}|{_description}|{_points}|{_isComplete}";
    }
}
