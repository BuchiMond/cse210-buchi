using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        Console.WriteLine($"Nice! You recorded '{_shortName}' and earned {_points} points.");
        // Eternal goals never complete
        return _points;
    }

    public override bool IsComplete()
    {
        return false; // never finished
    }

    public override string GetStringRepresentation()
    {
        // Format: EternalGoal:name|description|points
        return $"EternalGoal:{_shortName}|{_description}|{_points}";
    }
}
