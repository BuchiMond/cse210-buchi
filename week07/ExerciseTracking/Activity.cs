using System;

public abstract class Activity
{
    // Shared attributes
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public DateTime Date => _date;
    public int Minutes => _minutes;

    // Abstract methods to be implemented in derived classes
    public abstract double GetDistance(); // in km
    public abstract double GetSpeed();    // in km/h
    public abstract double GetPace();     // in min per km

    // Shared method to display a summary
    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {this.GetType().Name} ({_minutes} min) - " +
               $"Distance {GetDistance():0.00} km, Speed {GetSpeed():0.00} kph, Pace {GetPace():0.00} min/km";
    }
}
