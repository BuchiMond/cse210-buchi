using System;

// NegativeGoal = bad habit. Every time you record it, you LOSE points.
public class NegativeGoal : Goal
{
    private int _penalty;        // points lost each time
    private int _timesOccurred;  // how many times this bad habit has happened

    // "points" from base class is not really used as "gain", so we pass 0 there.
    public NegativeGoal(string name, string description, int penalty, int timesOccurred)
        : base(name, description, 0)
    {
        _penalty = penalty;
        _timesOccurred = timesOccurred;
    }

    public override int RecordEvent()
    {
        _timesOccurred++;
        int pointsLost = _penalty;

        Console.WriteLine(
            $"Oops! You recorded the bad habit '{_shortName}'. " +
            $"You lose {pointsLost} points. " +
            $"This has happened {_timesOccurred} time(s).");

        // Return negative value so the manager subtracts it from the score
        return -pointsLost;
    }

    public override bool IsComplete()
    {
        // Bad habits are never "complete" in this simple version.
        return false;
    }

    public override string GetDetailsString()
    {
        return $"{_shortName} ({_description}) -- Times occurred: {_timesOccurred}";
    }

    public override string GetStringRepresentation()
    {
        // Format: NegativeGoal:name|description|penalty|timesOccurred
        return $"NegativeGoal:{_shortName}|{_description}|{_penalty}|{_timesOccurred}";
    }
}
