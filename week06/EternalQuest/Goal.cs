using System;

public abstract class Goal
{
    // Shared fields (encapsulation: kept private/protected)
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Called when the user records this goal.
    // Returns how many points were earned.
    public abstract int RecordEvent();

    // Has this goal been completed? (Simple + Checklist can be true, Eternal is always false)
    public abstract bool IsComplete();

    // Text shown when listing goals
    public virtual string GetDetailsString()
    {
        return $"{_shortName} ({_description})";
    }

    // Used for saving to a file (type + data)
    public abstract string GetStringRepresentation();
}
