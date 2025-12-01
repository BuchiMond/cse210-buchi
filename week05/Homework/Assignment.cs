using System;

public class Assignment
{
    // Private member variables
    private string _studentName;
    private string _topic;

    // Constructor
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Method to return a summary
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    // Helper so derived classes can access the student name
    public string GetStudentName()
    {
        return _studentName;
    }
}
