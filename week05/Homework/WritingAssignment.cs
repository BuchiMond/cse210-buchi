using System;

public class WritingAssignment : Assignment
{
    // Extra member variable for Writing
    private string _title;

    // Constructor
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    // Method for writing information
    public string GetWritingInformation()
    {
        return $"{_title} by {GetStudentName()}";
    }
}
